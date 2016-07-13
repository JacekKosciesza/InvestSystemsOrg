import { Component, OnInit } from '@angular/core';

import { YahooFinanceService } from './yahoo-finance.service'

@Component({
    moduleId: module.id,
    selector: 'yahoo-finance',
    templateUrl: 'yahoo-finance.component.html',
    styleUrls: ['yahoo-finance.component.css'],
    providers: [YahooFinanceService]
})
export class YahooFinanceComponent implements OnInit {
    current: any;
    historical: any;
    constructor(private yfs: YahooFinanceService) { }

    ngOnInit() {
        this.yfs.Current("MENT").then(result => this.current = result)
        this.yfs.Historical("MENT").then(result => this.historical = result)
    }
}