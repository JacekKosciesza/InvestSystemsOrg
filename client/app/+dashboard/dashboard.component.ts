import { Component, OnInit } from '@angular/core';

import { CompaniesService } from '../+companies/companies.service';
import { PortfolioComponent } from './portfolio.component'
import { PortfolioService } from './portfolio.service'
import { WatchListComponent } from './watch-list.component'
import { WatchListService } from './watch-list.service'


@Component({
    moduleId: module.id,
    templateUrl: 'dashboard.component.html',
    directives: [PortfolioComponent, WatchListComponent],
    providers: [CompaniesService, PortfolioService, WatchListService] // TODO: move CompaniesService level up?
})
export class DashboardComponent implements OnInit {
}