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
var moment = require('moment');
var yahoo_finance_service_1 = require('./yahoo-finance.service');
var YahooFinanceComponent = (function () {
    function YahooFinanceComponent(yfs) {
        this.yfs = yfs;
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }
    YahooFinanceComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.yfs.Current("MENT").then(function (result) { return _this.current = result; });
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(this.getHistorical.bind(this));
    };
    YahooFinanceComponent.prototype.getHistorical = function () {
        var _this = this;
        //debugger;
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(function (result) {
            _this.historical = result.map(function (r) { return [new Date(r.Date), parseFloat(r.Close)]; });
            _this.drawChart();
        });
    };
    YahooFinanceComponent.prototype.drawChart = function () {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Date');
        data.addColumn('number', 'Price');
        data.addRows(this.historical);
        var options = {
            chart: {
                title: 'Historical Mentor Graphics Corporation data',
                subtitle: 'MENT'
            },
            //width: 900,
            height: 500
        };
        var chart = new google.charts.Line(document.getElementById('chart'));
        chart.draw(data, options);
    };
    YahooFinanceComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'yahoo-finance',
            templateUrl: 'yahoo-finance.component.html',
            styleUrls: ['yahoo-finance.component.css'],
            providers: [yahoo_finance_service_1.YahooFinanceService]
        }), 
        __metadata('design:paramtypes', [yahoo_finance_service_1.YahooFinanceService])
    ], YahooFinanceComponent);
    return YahooFinanceComponent;
}());
exports.YahooFinanceComponent = YahooFinanceComponent;
//# sourceMappingURL=yahoo-finance.component.js.map