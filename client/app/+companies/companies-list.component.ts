import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router-deprecated';

import { Company } from './company';
import { CompaniesService } from './companies.service';

@Component({
    moduleId: module.id,
    selector: 'companies-list',
    templateUrl: 'companies-list.component.html',
    styleUrls: ['companies-list.component.css']
})
export class CompaniesListComponent implements OnInit {
    companies: Company[];

    constructor(private companiesService: CompaniesService, private router: Router) { }

    ngOnInit() {
        this.companies = this.companiesService.getCompanies();
    }

    gotoDetail(company: Company) {
        let link = ['CompaniesDetail', {symbol:company.abbreviation}];
        this.router.navigate(link);
    }
}