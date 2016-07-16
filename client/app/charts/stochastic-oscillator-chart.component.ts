import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { ChartsService } from './charts.service'
import { Stochastic } from '../technical-indicators/stochastic'

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'stochastic-oscillator-chart',
    template: `<div id="stochastic-oscillator-chart"></div>`,
})
export class StochasticOscillatorChartComponent implements OnInit, OnChanges {
    @Input() stochastic: Stochastic[];
    chartsLoaded: boolean = false;

    constructor(private chartsService: ChartsService) {
        this.stochastic = [];
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
        if (changes['stochastic'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    }

    onChartsLoaded() {
        this.chartsLoaded = true;
        this.prepareDataAndDrawChart();
    }

    prepareDataAndDrawChart() {
        if (this.chartsLoaded && this.stochastic && this.stochastic.length) {
            let rows = this.stochastic.filter(sp => (sp.percentK != null && typeof sp.percentK !== 'undefined') || (sp.percentD != null && typeof sp.percentD !== 'undefined')).map(sp => sp.toRow());
            this.drawChart(rows);
        }
    }

    drawChart(rows) {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Buy line (%K)');
        data.addColumn('number', 'Sell line (%D)');
        //data.addColumn('number', 'Close Price');

        data.addRows(rows);

        var options = {
            chart: {
                title: 'Mentor Graphics Corporation (MENT)',
                subtitle: 'Stochastic Oscillator'
            },
            //width: 900,
            height: 500
        };

        var chart = new google.charts.Line(document.getElementById('stochastic-oscillator-chart')); // TODO: some unique identifier?

        chart.draw(data, options);
    }
}