import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router-deprecated';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stocks-list',
    templateUrl: 'stocks-list.component.html',
    styleUrls: ['stocks-list.component.css']
})
export class StocksListComponent implements OnInit {
    stocks: StockExchange[];

    constructor(private companiesService: StockService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        this.stocks = this.companiesService.getCompanies();
        this.titleService.setTitle('Stock Exchanges');
    }

    gotoDetail(stock: StockExchange) {
        let link = ['StockDetail', { id: stock.id }];
        this.router.navigate(link);
    }
}