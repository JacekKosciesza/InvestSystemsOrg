import { Component, OnInit } from '@angular/core';

import { CompaniesService } from '../+companies/companies.service';
import { PortfolioComponent } from './portfolio.component'
import { WatchListComponent } from './watch-list.component'


@Component({
    moduleId: module.id,
    templateUrl: 'dashboard.component.html',
    directives: [PortfolioComponent, WatchListComponent],
    providers: [CompaniesService] // TODO: move it one level up?
})
export class DashboardComponent implements OnInit {
}