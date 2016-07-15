import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { StockPrice } from './stock-price'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'stock-prices-chart',
    templateUrl: 'stock-prices-chart.component.html',
    styleUrls: ['stock-prices-chart.component.css']
})
export class StockPricesChartComponent implements OnInit, OnChanges {
    @Input() stockPrices: StockPrice[];

    constructor() {
        this.stockPrices = [];
    }

    ngOnInit() {
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.prepareDataAndDrawChart.bind(this));
    }

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        if (changes['stockPrices'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    }

    prepareDataAndDrawChart() {
        if (this.stockPrices && this.stockPrices.length) {
            let rows = this.stockPrices.map(sp => sp.toRow());
            this.drawChart(rows);
        }
    }

    drawChart(rows) {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Price');

        data.addRows(rows);

        var options = {
            chart: {
                title: 'Mentor Graphics Corporation',
                subtitle: 'MENT'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('chart'));

        chart.draw(data, options);
    }
}