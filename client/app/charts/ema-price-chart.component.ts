import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { ChartsService } from './charts.service'
import { EMA } from '../technical-indicators/ema'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'ema-price-chart',
    template: `<div id="ema-price-chart"></div>`
})
export class EmaPriceChartComponent implements OnInit, OnChanges {
    @Input() ema: EMA[];
    chartsLoaded: boolean = false;

    constructor(private chartsService: ChartsService) {
        this.ema = [];
    }

    ngOnInit() {
        this.chartsService.load();
        this.chartsService.chartsLoaded$.subscribe(loaded => {
            this.chartsLoaded = loaded;
            this.prepareDataAndDrawChart();
        });
    }

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        if (changes['ema'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    }

    prepareDataAndDrawChart() {
        if (this.chartsLoaded && this.ema && this.ema.length) {
            let rows = this.ema.filter(sp => (sp.ema != null && typeof sp.ema !== 'undefined')).map(sp => sp.toRow());
            this.drawChart(rows);
        }
    }

    drawChart(rows) {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Close Price');
        data.addColumn('number', 'EMA');

        data.addRows(rows);

        var options = {
            chart: {
                title: 'Mentor Graphics Corporation (MENT)',
                subtitle: 'EMA & Close Price'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('ema-price-chart')); // TODO: some unique identifier?

        chart.draw(data, options);
    }
}