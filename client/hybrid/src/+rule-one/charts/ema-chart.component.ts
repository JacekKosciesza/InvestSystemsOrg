import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

//import { ChartsService } from './charts.service'
import { EMAData } from './ema-data.model'

declare var google: any;

@Component({
    selector: 'ema-chart',
    template: 
    `
        <div id="ema-chart"></div>
        <footer class="legend">
            <ion-icon name="square"></ion-icon> Price
            <ion-icon name="square"></ion-icon> EMA
        </footer>
    `
})
export class EmaChartComponent implements OnInit, OnChanges {
    @Input() title: string;
    @Input() data: EMAData[];
    //chartsLoaded: boolean = false;

    constructor(/*private chartsService: ChartsService*/) {
        this.data = [];
    }

    ngOnInit() {
        // TODO: use service or make sure other way that charts are loaded (google.charts.load does not trigger callback for some reason)
        //this.chartsService.load();
        // this.chartsService.chartsLoaded$.subscribe(loaded => {
        //     this.chartsLoaded = loaded;
        //     this.prepareDataAndDrawChart();
        // });
    }

    ngOnChanges(changes: { [propKey: string]: SimpleChange }) {
        if (changes['data'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    }

    prepareDataAndDrawChart() {
        if (/*this.chartsLoaded && */this.data && this.data.length) {
            let rows = this.data.filter(sp => (sp.ema != null && typeof sp.ema !== 'undefined')).map(sp => sp.toRow());
            this.drawChart(rows);
        }
    }

    drawChart(rows) {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Price');
        data.addColumn('number', 'EMA');

        data.addRows(rows);

        var options = {
            chart: {
                title: this.title
            },
            legend: {position: 'none'}, // TODO: bottom when it will be supported
            colors:['#4285F4','#F4B400']
        };

        var chart = new google.charts.Line(document.getElementById('ema-chart')); // TODO: some unique identifier?

        chart.draw(data, options);
    }
}