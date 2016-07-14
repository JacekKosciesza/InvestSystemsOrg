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
var StockPricesChartComponent = (function () {
    function StockPricesChartComponent() {
        this.stockPrices = [];
    }
    StockPricesChartComponent.prototype.ngOnInit = function () {
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.prepareDataAndDrawChart.bind(this));
    };
    StockPricesChartComponent.prototype.ngOnChanges = function (changes) {
        debugger;
        if (changes['stockPrices'].currentValue) {
            this.prepareDataAndDrawChart();
        }
    };
    StockPricesChartComponent.prototype.prepareDataAndDrawChart = function () {
        if (this.stockPrices && this.stockPrices.length) {
            var rows = this.stockPrices.map(function (sp) { return sp.toRow(); });
            this.drawChart(rows);
        }
    };
    StockPricesChartComponent.prototype.drawChart = function (rows) {
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
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], StockPricesChartComponent.prototype, "stockPrices", void 0);
    StockPricesChartComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stock-prices-chart',
            templateUrl: 'stock-prices-chart.component.html',
            styleUrls: ['stock-prices-chart.component.css']
        }), 
        __metadata('design:paramtypes', [])
    ], StockPricesChartComponent);
    return StockPricesChartComponent;
}());
exports.StockPricesChartComponent = StockPricesChartComponent;
//# sourceMappingURL=stock-prices-chart.component.js.map