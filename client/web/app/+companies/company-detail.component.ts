import { Component, OnDestroy, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

import { FirebaseObjectObservable } from 'angularfire2';


import { Company } from './company';
import { CompaniesService } from './companies.service';

@Component({
    moduleId: module.id,
    selector: 'company-detail',
    templateUrl: 'company-detail.component.html',
    styleUrls: ['company-detail.component.css']
})
export class CompanyDetailComponent implements OnInit, OnDestroy {
    company: FirebaseObjectObservable<Company>;
    private routeParams: any; // TODO: strongly type it

    constructor(private companiesService: CompaniesService, private route: ActivatedRoute, private titleService: Title) { }

    ngOnInit() {
        //let symbol = this.route.snapshot.params['symbol'];

        this.routeParams = this.route.params.subscribe(params => {
            let symbol = params['symbol'];
            this.company = this.companiesService.getCompany(symbol);
        });
    }

    ngOnDestroy() {
        this.routeParams.unsubscribe();
    }

    save(newName: string) {
        this.company.set({ name: newName });
    }
    update(newSize: string) {
        this.company.update({ size: newSize });
    }
    delete() {
        this.company.remove();
    }
}