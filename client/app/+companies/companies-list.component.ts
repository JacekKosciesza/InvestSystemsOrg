import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router-deprecated';

import { FirebaseListObservable } from 'angularfire2';

import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

import { Company } from './company';
import { CompaniesService } from './companies.service';

@Component({
    moduleId: module.id,
    selector: 'companies-list',
    templateUrl: 'companies-list.component.html',
    styleUrls: ['companies-list.component.css'],
    directives: [MD_CARD_DIRECTIVES]
})
export class CompaniesListComponent implements OnInit {
    companies: FirebaseListObservable<Company[]>;

    constructor(private companiesService: CompaniesService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        this.companies = this.companiesService.getCompanies();
        this.titleService.setTitle('Companies');
    }

    gotoDetail(company: Company) {
        let link = ['CompaniesDetail', { symbol: company.$key }];
        this.router.navigate(link);
    }
}