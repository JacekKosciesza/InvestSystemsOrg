import { Component, OnInit } from '@angular/core';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { PortfolioService } from './portfolio.service';

@Component({
    selector: 'user-portfolio',
    templateUrl: 'build/+dashboard/portfolio/user-portfolio.component.html',
    pipes: [TranslatePipe],
    providers: [PortfolioService]
})
export class UserPortfolioComponent implements OnInit {
    companies: any[];

    constructor(private portfolioService: PortfolioService) { }

    ngOnInit() {
        this.portfolioService.getWatchlist('79A75268-CB36-4E7A-918B-FE3A76C7BB82').then(companies => {
            this.companies = companies;
        });
    }
}