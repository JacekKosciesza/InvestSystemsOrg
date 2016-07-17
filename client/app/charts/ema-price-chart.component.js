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
var charts_service_1 = require('./charts.service');
var EmaPriceChartComponent = (function () {
    function EmaPriceChartComponent(chartsService) {
        this.chartsService = chartsService;
        this.chartsLoaded = false;
        this.ema = [];
    }
    EmaPriceChartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.chartsService.load();
        this.chartsService.chartsLoaded$.subscribe(function (loaded) {
            _this.chartsLoaded = loaded;
            _this.prepareDataAndDrawChart();
        });
    };
    EmaPriceChartComponent.prototype.ngOnChanges = function (changes) {
        if (changes['ema'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    };
    EmaPriceChartComponent.prototype.onChartsLoaded = function () {
        this.chartsLoaded = true;
        this.prepareDataAndDrawChart();
    };
    EmaPriceChartComponent.prototype.prepareDataAndDrawChart = function () {
        if (this.chartsLoaded && this.ema && this.ema.length) {
            var rows = this.ema.filter(function (sp) { return (sp.ema != null && typeof sp.ema !== 'undefined'); }).map(function (sp) { return sp.toRow(); });
            this.drawChart(rows);
        }
    };
    EmaPriceChartComponent.prototype.drawChart = function (rows) {
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
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], EmaPriceChartComponent.prototype, "ema", void 0);
    EmaPriceChartComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'ema-price-chart',
            template: "<div id=\"ema-price-chart\"></div>"
        }), 
        __metadata('design:paramtypes', [charts_service_1.ChartsService])
    ], EmaPriceChartComponent);
    return EmaPriceChartComponent;
}());
exports.EmaPriceChartComponent = EmaPriceChartComponent;
//# sourceMappingURL=ema-price-chart.component.js.map