import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { ChartsService } from './charts.service'
import { MACD } from '../technical-indicators/macd'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'macd-signal-chart',
    template: `<div id="macd-signal-chart"></div>`
})
export class MacdSignalChartComponent implements OnInit, OnChanges {
    @Input() macd: MACD[];
    chartsLoaded: boolean = false;

    constructor(private chartsService: ChartsService) {
        this.macd = [];
    }

    ngOnInit() {
        this.chartsService.load();
        this.chartsService.chartsLoaded$.subscribe(loaded => {
            this.chartsLoaded = loaded;
        });
        // google.charts.load('current', { 'packages': ['line'] });
        // google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
    }

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        if (changes['macd'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    }

    onChartsLoaded() {
        this.chartsLoaded = true;
        this.prepareDataAndDrawChart();
    }

    prepareDataAndDrawChart() {
        if (this.chartsLoaded && this.macd && this.macd.length) {
            let rows = this.macd.filter(sp => (sp.macd != null && typeof sp.macd !== 'undefined') || (sp.signal != null && typeof sp.signal !== 'undefined')).map(sp => sp.toRow());
            this.drawChart(rows);
        }
    }

    drawChart(rows) {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'MACD');
        data.addColumn('number', 'Signal');

        data.addRows(rows);

        var options = {
            chart: {
                title: 'Mentor Graphics Corporation (MENT)',
                subtitle: 'MACD & Signal'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('macd-signal-chart')); // TODO: some unique identifier?

        chart.draw(data, options);
    }
}