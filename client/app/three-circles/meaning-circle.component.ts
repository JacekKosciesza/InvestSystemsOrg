import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

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

    constructor(private circleDataService: CircleDataService) { }

    ngOnInit() {
        this.circleDataService.getAreas(this.type)
            .then(heroes => this.areas = heroes.map(a => new MeaningAreaView(a)));
    }

    ngOnChanges(changes: {[propKey: string]: SimpleChange}) {
        console.log('ngOnChanges');
    }
}