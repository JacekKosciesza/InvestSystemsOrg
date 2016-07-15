import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { MACD } from '../technical-indicators/macd'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'macd-signal-chart',
    template: `<div id="chart"></div>`,
})
export class MacdSignalChartComponent implements OnInit, OnChanges {
    @Input() macd: MACD[];
    chartsLoaded: boolean = false;

    constructor() {
        this.macd = [];
    }

    ngOnInit() {
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
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

        var chart = new google.charts.Line(document.getElementById('chart'));

        chart.draw(data, options);
    }
}