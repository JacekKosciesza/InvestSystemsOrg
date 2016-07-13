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
    result: any;
    constructor(private yfs: YahooFinanceService) { }

    ngOnInit() {
        this.yfs.HelloYQL().then(result => this.result = result)
    }
}