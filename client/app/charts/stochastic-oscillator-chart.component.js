"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var StochasticOscillatorChartComponent = (function () {
    function StochasticOscillatorChartComponent() {
        this.chartsLoaded = false;
        this.stochastic = [];
    }
    StochasticOscillatorChartComponent.prototype.ngOnInit = function () {
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
    };
    StochasticOscillatorChartComponent.prototype.ngOnChanges = function (changes) {
        if (changes['stochastic'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    };
    StochasticOscillatorChartComponent.prototype.onChartsLoaded = function () {
        this.chartsLoaded = true;
        this.prepareDataAndDrawChart();
    };
    StochasticOscillatorChartComponent.prototype.prepareDataAndDrawChart = function () {
        if (this.chartsLoaded && this.stochastic && this.stochastic.length) {
            var rows = this.stochastic.filter(function (sp) { return (sp.percentK != null && typeof sp.percentK !== 'undefined') || (sp.percentD != null && typeof sp.percentD !== 'undefined'); }).map(function (sp) { return sp.toRow(); });
            this.drawChart(rows);
        }
    };
    StochasticOscillatorChartComponent.prototype.drawChart = function (rows) {
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
        var chart = new google.charts.Line(document.getElementById('chart'));
        chart.draw(data, options);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], StochasticOscillatorChartComponent.prototype, "stochastic", void 0);
    StochasticOscillatorChartComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stochastic-oscillator-chart',
            template: "<div id=\"chart\"></div>",
        }), 
        __metadata('design:paramtypes', [])
    ], StochasticOscillatorChartComponent);
    return StochasticOscillatorChartComponent;
}());
exports.StochasticOscillatorChartComponent = StochasticOscillatorChartComponent;
//# sourceMappingURL=stochastic-oscillator-chart.component.js.map