import { Component, OnInit } from '@angular/core';

import * as moment from 'moment';

import { YahooFinanceService } from './yahoo-finance.service'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'yahoo-finance',
    templateUrl: 'yahoo-finance.component.html',
    styleUrls: ['yahoo-finance.component.css'],
    providers: [YahooFinanceService]
})
export class YahooFinanceComponent implements OnInit {
    startDate: string;
    endDate: string;
    current: any;
    historical: any;
    constructor(private yfs: YahooFinanceService) {
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }

    ngOnInit() {
        this.yfs.Current("MENT").then(result => this.current = result)
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.getHistorical.bind(this));
    }

    getHistorical() {
        //debugger;
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(result => {
            this.historical = result.map(r => { return [new Date(r.Date), parseFloat(r.Close)] });
            this.drawChart();
        });
    }

    drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Price');

        data.addRows(this.historical);

        var options = {
            chart: {
                title: 'Historical Mentor Graphics Corporation data',
                subtitle: 'MENT'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('chart'));

        chart.draw(data, options);
    }
}