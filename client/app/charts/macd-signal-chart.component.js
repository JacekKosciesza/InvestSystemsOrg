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
var MacdSignalChartComponent = (function () {
    function MacdSignalChartComponent() {
        this.chartsLoaded = false;
        this.macd = [];
    }
    MacdSignalChartComponent.prototype.ngOnInit = function () {
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
    };
    MacdSignalChartComponent.prototype.ngOnChanges = function (changes) {
        if (changes['macd'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    };
    MacdSignalChartComponent.prototype.onChartsLoaded = function () {
        this.chartsLoaded = true;
        this.prepareDataAndDrawChart();
    };
    MacdSignalChartComponent.prototype.prepareDataAndDrawChart = function () {
        if (this.chartsLoaded && this.macd && this.macd.length) {
            var rows = this.macd.filter(function (sp) { return (sp.macd != null && typeof sp.macd !== 'undefined') || (sp.signal != null && typeof sp.signal !== 'undefined'); }).map(function (sp) { return sp.toRow(); });
            this.drawChart(rows);
        }
    };
    MacdSignalChartComponent.prototype.drawChart = function (rows) {
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
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], MacdSignalChartComponent.prototype, "macd", void 0);
    MacdSignalChartComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'macd-signal-chart',
            template: "<div id=\"chart\"></div>",
        }), 
        __metadata('design:paramtypes', [])
    ], MacdSignalChartComponent);
    return MacdSignalChartComponent;
}());
exports.MacdSignalChartComponent = MacdSignalChartComponent;
//# sourceMappingURL=macd-signal-chart.component.js.map