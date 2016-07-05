import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { RouteParams } from '@angular/router-deprecated';

import { FirebaseObjectObservable } from 'angularfire2';


import { Company } from './company';
import { CompaniesService } from './companies.service';

@Component({
    moduleId: module.id,
    selector: 'company-detail',
    templateUrl: 'company-detail.component.html',
    styleUrls: ['company-detail.component.css']
})
export class CompanyDetailComponent implements OnInit {
    company: FirebaseObjectObservable<Company>;

    constructor(private companiesService: CompaniesService, private routeParams: RouteParams, private titleService: Title) { }

    ngOnInit() {
        if (this.routeParams.get('symbol') !== null) {
            let symbol = this.routeParams.get('symbol');
            this.company = this.companiesService.getCompany(symbol);
            //this.titleService.setTitle(this.company.fullName);
        }
    }
}