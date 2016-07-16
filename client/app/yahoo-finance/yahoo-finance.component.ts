import { Component, OnInit } from '@angular/core';

import * as moment from 'moment';

import { YahooFinanceService } from './yahoo-finance.service'
import { StockPricesChartComponent } from '../charts/stock-prices-chart.component'
import { MacdSignalChartComponent } from '../charts/macd-signal-chart.component'
import { StochasticOscillatorChartComponent } from '../charts/stochastic-oscillator-chart.component'

import { StockPrice } from '../charts/stock-price'

import { MACDService } from '../technical-indicators/macd.service'
import { MCDA_TEST_DATA } from '../technical-indicators/macd-test-data'

import { StochasticService } from '../technical-indicators/stochastic.service'
import { STOCHASTIC_TEST_DATA } from '../technical-indicators/stochastic-test-data'
import { OHLC } from '../technical-indicators/ohlc'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'yahoo-finance',
    templateUrl: 'yahoo-finance.component.html',
    styleUrls: ['yahoo-finance.component.css'],
    providers: [YahooFinanceService, MACDService, StochasticService],
    directives: [StockPricesChartComponent, MacdSignalChartComponent, StochasticOscillatorChartComponent]
})
export class YahooFinanceComponent implements OnInit {
    startDate: string;
    endDate: string;
    current: any;
    historical: StockPrice[];
    macd: any;
    stochastic: any;
    constructor(private yfs: YahooFinanceService, private macdService: MACDService, private stochasticService: StochasticService) {
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }

    ngOnInit() {
        //this.yfs.Current("MENT").then(result => this.current = result)
        this.getHistorical();
        //this.macd =  this.macdService.calculate(MCDA_TEST_DATA);
        //this.stochastic =  this.stochasticService.calculate(STOCHASTIC_TEST_DATA);
    }

    getHistorical() {
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(result => {
            this.historical = result.map(r => new StockPrice(new Date(r.Date), parseFloat(r.Close)));
            this.macd =  this.macdService.calculate(this.historical);
            
            let ohlcData = result.map(r => new OHLC(new Date(r.Date), parseFloat(r.Open), parseFloat(r.High), parseFloat(r.Low), parseFloat(r.Close)));
            this.stochastic =  this.stochasticService.calculate(ohlcData);
        });
    }
}