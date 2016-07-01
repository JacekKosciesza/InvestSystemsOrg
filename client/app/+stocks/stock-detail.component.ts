import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { RouteParams } from '@angular/router-deprecated';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stock-detail',
    templateUrl: 'stock-detail.component.html',
    styleUrls: ['stock-detail.component.css']
})
export class StockDetailComponent implements OnInit {
    stock: StockExchange;

    constructor(private companiesService: StockService, private routeParams: RouteParams, private titleService: Title) { }

    ngOnInit() {
        if (this.routeParams.get('id') !== null) {
            let symbol = this.routeParams.get('id');
            this.stock = this.companiesService.getCompany(symbol);
            this.titleService.setTitle(this.stock.name);
        }
    }
}