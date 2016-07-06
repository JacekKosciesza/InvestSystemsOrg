import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

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

    constructor(private companiesService: StockService, private route: ActivatedRoute, private titleService: Title) { }

    ngOnInit() {
        let symbol = this.route.snapshot.params['symbol'];
        if (symbol) {
            this.stock = this.companiesService.getCompany(symbol);
            this.titleService.setTitle(this.stock.name);
        }
    }
}