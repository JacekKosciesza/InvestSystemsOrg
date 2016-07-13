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
    }
    YahooFinanceService.prototype.HelloYQL = function () {
        var BASE_URL = 'http://query.yahooapis.com/v1/public/yql?q=';
        var yql_import = "env 'store://datatables.org/alltableswithkeys';";
        var yql_query = 'select * from yahoo.finance.quote where symbol in ("YHOO","GOOG","MSFT")';
        var yql_extra = '&format=json';
        var query_str_final = "" + BASE_URL + yql_import + yql_query + yql_extra;
        return this.http.get(query_str_final)
            .toPromise()
            .then(function (response) { return response.json(); });
    };
    YahooFinanceService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], YahooFinanceService);
    return YahooFinanceService;
}());
exports.YahooFinanceService = YahooFinanceService;
//# sourceMappingURL=yahoo-finance.service.js.map