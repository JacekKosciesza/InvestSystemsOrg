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
var http_1 = require('@angular/http');
var YahooFinanceService = (function () {
    function YahooFinanceService(http) {
        this.http = http;
        this.BASE_URL = 'http://query.yahooapis.com/v1/public/yql?q=';
        this.YQL_IMPORT = "env 'store://datatables.org/alltableswithkeys';";
        this.YQL_EXTRA = '&format=json';
    }
    YahooFinanceService.prototype.Current = function (symbol) {
        var yql_query = "select * from yahoo.finance.quote where symbol = \"" + symbol + "\"";
        return this.Get(yql_query);
    };
    YahooFinanceService.prototype.Historical = function (symbol) {
        var yql_query = "select * from yahoo.finance.historicaldata where symbol = \"" + symbol + "\" and startDate = \"2015-07-13\" and endDate = \"2016-07-13\"";
        return this.Get(yql_query);
    };
    YahooFinanceService.prototype.Get = function (yql_query) {
        var query_str_final = "" + this.BASE_URL + this.YQL_IMPORT + yql_query + this.YQL_EXTRA;
        return this.http.get(query_str_final)
            .toPromise()
            .then(function (response) { return response.json().query.results.quote; });
    };
    YahooFinanceService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], YahooFinanceService);
    return YahooFinanceService;
}());
exports.YahooFinanceService = YahooFinanceService;
//# sourceMappingURL=yahoo-finance.service.js.map