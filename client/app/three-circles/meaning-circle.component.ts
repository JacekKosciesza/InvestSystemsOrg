import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/retry';

import { MeaningCircleType } from './meaning-circle-type'
import { MeaningCircleSubtype } from './meaning-circle-subtype'
import { MeaningAreaView } from './meaning-area-view'
import { CircleDataService } from './circle-data.service'

@Component({
    moduleId: module.id,
    selector: 'meaning-circle',
    templateUrl: 'meaning-circle.component.html',
    styleUrls: ['meaning-circle.component.css']
})
export class MeaningCircleComponent implements OnInit, OnChanges {
    @Input() type: MeaningCircleType;
    areas: MeaningAreaView[];
    private suggestionsStream = new Subject<string>();

    add(name: string) {
        if (name) {
            this.circleDataService.save({id: 0, name: name, type: this.type, subtype: MeaningCircleSubtype.None});
        }
    }

    delete(area: MeaningAreaView) {
        var index = this.areas.findIndex(a => a === area);
        if (index > -1) {
            this.areas.splice(index, 1);
        }
    }

    suggest(term: string) {
        this.suggestionsStream.next(term);
    }

    suggestions: Observable<string[]> = this.suggestionsStream
        .debounceTime(300)
        .distinctUntilChanged()
        .switchMap((term: string) => this.circleDataService.suggest(term).retry(3));

    constructor(private circleDataService: CircleDataService) { }

    ngOnInit() {
        this.circleDataService.getAreas(this.type)
            .then(heroes => this.areas = heroes.map(a => new MeaningAreaView(a)));
    }

    ngOnChanges(changes: {[propKey: string]: SimpleChange}) {
        //console.log('ngOnChanges');
    }
}