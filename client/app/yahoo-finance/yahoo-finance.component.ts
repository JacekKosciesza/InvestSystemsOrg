import { Component, OnInit } from '@angular/core';

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
    current: any;
    historical: any;
    constructor(private yfs: YahooFinanceService) { }

    ngOnInit() {
        this.yfs.Current("MENT").then(result => this.current = result)
        this.yfs.Historical("MENT").then(result => {
            //debugger;
            this.historical = result.map(r => { return [new Date(r.Date), parseFloat(r.Close)]});
            google.charts.load('current', {'packages':['line']});
            google.charts.setOnLoadCallback(this.drawChart.bind(this));
        });
    }

    drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Price');

        data.addRows(this.historical 
        // [
        //     [new Date(2016, 7, 12), 21.84],
        //     [new Date(2016, 7, 11), 21.59],
        // ]
        );

        var options = {
            chart: {
                title: 'Historical Mentor Graphics Corporation data',
                subtitle: 'MENT'
            },
            width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('chart'));

        chart.draw(data, options);
    }
}