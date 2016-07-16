import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { ChartsService } from './charts.service'
import { StockPrice } from './stock-price'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'stock-prices-chart',
    template: `<div id="stock-prices-chart"></div>`
})
export class StockPricesChartComponent implements OnInit, OnChanges {
    @Input() stockPrices: StockPrice[];

    constructor(private chartsService: ChartsService) {
        this.stockPrices = [];
    }

    ngOnInit() {
        this.chartsService.load();
        this.chartsService.chartsLoaded$.subscribe(loaded => {
            this.chartsLoaded = loaded;
        });
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
        data.addColumn('number', 'Close price');

        data.addRows(rows);

        var options = {
            chart: {
                title: 'Mentor Graphics Corporation (MENT)',
                subtitle: 'Historical close prices'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('stock-prices-chart')); // TODO: some unique identifier?

        chart.draw(data, options);
    }
}