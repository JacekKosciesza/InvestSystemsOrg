import { Component, OnInit } from '@angular/core';

import { PortfolioService } from './portfolio.service';
import { ToastService, Toast } from '../../services'

@Component({
    selector: 'user-portfolio',
    templateUrl: 'user-portfolio.component.html'
})
export class UserPortfolioComponent implements OnInit {
    public companies: any[];

    constructor(private portfolioService: PortfolioService, private toastService: ToastService) { }

    ngOnInit() {
        this.portfolioService.getWatchlist('79A75268-CB36-4E7A-918B-FE3A76C7BB82').then(companies => {
            this.companies = companies;
        });
    }

    like(company) {
        this.toastService.show(new Toast(company.name, 3000));
    }
}