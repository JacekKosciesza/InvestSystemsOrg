import { Component, OnDestroy, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

import { FirebaseObjectObservable } from 'angularfire2';

import { Sector } from './sector';
import { SectorsService } from './sectors.service';

@Component({
    moduleId: module.id,
    selector: 'sector-detail',
    templateUrl: 'sector-detail.component.html'
})
export class SectorDetailComponent implements OnInit, OnDestroy {
    company: FirebaseObjectObservable<Sector>;
    private routeParams: any; // TODO: strongly type it

    constructor(private sectorsService: SectorsService, private route: ActivatedRoute, private titleService: Title) { }

    ngOnInit() {
        this.routeParams = this.route.params.subscribe(params => {
            let id = params['id'];
            this.company = this.sectorsService.getSector(id);
        });
    }

    ngOnDestroy() {
        this.routeParams.unsubscribe();
    }

    // save(newName: string) {
    //     this.company.set({ name: newName });
    // }
    // update(newSize: string) {
    //     this.company.update({ size: newSize });
    // }
    // delete() {
    //     this.company.remove();
    // }
}