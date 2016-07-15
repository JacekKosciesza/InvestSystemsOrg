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
var stock_prices_chart_component_1 = require('../charts/stock-prices-chart.component');
var macd_signal_chart_component_1 = require('../charts/macd-signal-chart.component');
var stock_price_1 = require('../charts/stock-price');
var macd_service_1 = require('../technical-indicators/macd.service');
var YahooFinanceComponent = (function () {
    function YahooFinanceComponent(yfs, macdService) {
        this.yfs = yfs;
        this.macdService = macdService;
        this.startDate = moment().subtract(1, 'years').format('YYYY-MM-DD');
        this.endDate = moment().format('YYYY-MM-DD');
    }
    YahooFinanceComponent.prototype.ngOnInit = function () {
        //this.yfs.Current("MENT").then(result => this.current = result)
        this.getHistorical();
        //this.macd =  this.macdService.calculate(MCDA_TEST_DATA);
    };
    YahooFinanceComponent.prototype.getHistorical = function () {
        var _this = this;
        this.yfs.Historical("MENT", new Date(this.startDate), new Date(this.endDate)).then(function (result) {
            _this.historical = result.map(function (r) { return new stock_price_1.StockPrice(new Date(r.Date), parseFloat(r.Close)); });
            _this.macd = _this.macdService.calculate(_this.historical);
        });
    };
    YahooFinanceComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'yahoo-finance',
            templateUrl: 'yahoo-finance.component.html',
            styleUrls: ['yahoo-finance.component.css'],
            providers: [yahoo_finance_service_1.YahooFinanceService, macd_service_1.MACDService],
            directives: [stock_prices_chart_component_1.StockPricesChartComponent, macd_signal_chart_component_1.MacdSignalChartComponent]
        }), 
        __metadata('design:paramtypes', [yahoo_finance_service_1.YahooFinanceService, macd_service_1.MACDService])
    ], YahooFinanceComponent);
    return YahooFinanceComponent;
}());
exports.YahooFinanceComponent = YahooFinanceComponent;
//# sourceMappingURL=yahoo-finance.component.js.map