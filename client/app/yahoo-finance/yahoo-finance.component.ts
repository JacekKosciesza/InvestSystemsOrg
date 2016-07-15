import { Component, OnInit } from '@angular/core';

import * as moment from 'moment';

import { YahooFinanceService } from './yahoo-finance.service'
import { StockPricesChartComponent } from '../charts/stock-prices-chart.component'
import { StockPrice } from '../charts/stock-price'

import { MACD, MCDA_TEST_DATA } from '../technical-indicators/mcda'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'yahoo-finance',
    templateUrl: 'yahoo-finance.component.html',
    styleUrls: ['yahoo-finance.component.css'],
    providers: [YahooFinanceService, MACD],
    directives: [StockPricesChartComponent]
})
export class YahooFinanceComponent implements OnInit {
    startDate: string;
    endDate: string;
    current: any;
    historical: StockPrice[];
    macd: any;
    constructor(private yfs: YahooFinanceService, private macdService: MACD) {
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }

    ngOnInit() {
        //this.yfs.Current("MENT").then(result => this.current = result)
        //this.getHistorical();
        this.macd =  this.macdService.calculate(MCDA_TEST_DATA);
    }

    getHistorical() {
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(result => {
            this.historical = result.map(r => new StockPrice(new Date(r.Date), parseFloat(r.Close)));
        });
    }
}