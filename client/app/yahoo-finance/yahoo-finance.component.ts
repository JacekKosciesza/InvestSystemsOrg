import { Component, OnInit } from '@angular/core';

import * as moment from 'moment';

import { YahooFinanceService } from './yahoo-finance.service'
import { StockPricesChartComponent } from '../charts/stock-prices-chart.component'
import { StockPrice } from '../charts/stock-price'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'yahoo-finance',
    templateUrl: 'yahoo-finance.component.html',
    styleUrls: ['yahoo-finance.component.css'],
    providers: [YahooFinanceService],
    directives: [StockPricesChartComponent]
})
export class YahooFinanceComponent implements OnInit {
    startDate: string;
    endDate: string;
    current: any;
    historical: StockPrice[];
    constructor(private yfs: YahooFinanceService) {
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }

    ngOnInit() {
        this.yfs.Current("MENT").then(result => this.current = result)
        this.getHistorical();
    }

    getHistorical() {
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(result => {
            this.historical = result.map(r => new StockPrice(new Date(r.Date), parseFloat(r.Close)));
        });
    }
}