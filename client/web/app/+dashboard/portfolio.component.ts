import { Component, OnInit } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { PortfolioService } from './portfolio.service'
import { Company } from '../+companies/company'; // TODO: move to shared?
import { CompaniesListComponent } from '../+companies/companies-list.component'

@Component({
    moduleId: module.id,
    selector: 'my-portfolio',
    templateUrl: 'portfolio.component.html',
    directives: [CompaniesListComponent]
})
export class PortfolioComponent implements OnInit {
    companies: FirebaseListObservable<any[]>;
    user: string = 'jacek-kosciesza'; // TOOD: get it from identidy service
    constructor(private portfolioService: PortfolioService) { }

    ngOnInit() {
        this.companies = this.portfolioService.getCompanies(this.user);
    }
}