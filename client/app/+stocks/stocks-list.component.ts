import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { FirebaseListObservable } from 'angularfire2';

import { MD_GRID_LIST_DIRECTIVES } from '@angular2-material/grid-list'
import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stocks-list',
    templateUrl: 'stocks-list.component.html',
    styleUrls: ['stocks-list.component.css'],
    directives: [MD_GRID_LIST_DIRECTIVES, MD_CARD_DIRECTIVES]
})
export class StocksListComponent implements OnInit {
    stocks: FirebaseListObservable<StockExchange[]>;

    constructor(private companiesService: StockService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        this.stocks = this.companiesService.getCompanies();
        this.titleService.setTitle('Stock Exchanges');
    }

    gotoDetail(stock: StockExchange) {
        let link = ['/stock-exchanges', stock.id];
        this.router.navigate(link);
    }
}