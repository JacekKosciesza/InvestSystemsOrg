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
var StockService = (function () {
    function StockService() {
        // https://en.wikipedia.org/wiki/Stock_exchange
        this.stocks = [
            {
                "id": "Nasdaq",
                "name": "Nasdaq",
                "website": "http://www.nasdaq.com/",
            },
            {
                "id": "NYSE",
                "name": "New York Stock Exchange",
                "website": "https://www.nyse.com/",
            },
            {
                "id": "LSEG",
                "name": "London Stock Exchange Group",
                "website": "http://www.lseg.com/",
            },
            {
                "id": "JPX",
                "name": "Japan Exchange Group",
                "website": "http://www.jpx.co.jp/",
            },
            {
                "id": "SSE",
                "name": "Shanghai Stock Exchange",
                "website": "http://www.sse.com.cn/",
            },
            {
                "id": "HKEX",
                "name": "Hong Kong Stock Exchange",
                "website": "http://www.hkex.com.hk/",
            },
            {
                "id": "Euronext",
                "name": "Euronext",
                "website": "https://www.euronext.com/",
            },
            {
                "id": "SZSE",
                "name": "Shenzhen Stock Exchange",
                "website": "http://www.szse.cn/",
            },
            {
                "id": "TMX",
                "name": "TMX Group",
                "website": "http://www.tmx.com/",
            },
            {
                "id": "Deutsche_Borse",
                "name": "Deutsche Börse",
                "website": "http://deutsche-boerse.com",
            },
            {
                "id": "BSE",
                "name": "Bombay Stock Exchange",
                "website": "http://www.bseindia.com/",
            },
            {
                "id": "NSE",
                "name": "National Stock Exchange of India",
                "website": "http://www.nseindia.com/",
            },
            {
                "id": "SIX_Swiss_Exchange",
                "name": "SIX Swiss Exchange",
                "website": "http://www.six-swiss-exchange.com/",
            },
            {
                "id": "ASX",
                "name": "Australian Securities Exchange",
                "website": "http://www.asx.com.au/",
            },
            {
                "id": "KRX",
                "name": "Korea Exchange",
                "website": "http://www.krx.co.kr/",
            },
            {
                "id": "OMX",
                "name": "OMX",
                "website": "http://www.omxnordicexchange.com/",
            },
            {
                "id": "JSE",
                "name": "JSE",
                "website": "http://www.jse.co.za/",
            },
            {
                "id": "BME",
                "name": "Bolsas y Mercados Españoles",
                "website": "http://www.bolsasymercados.es/",
            },
            {
                "id": "TWSE",
                "name": "Taiwan Stock Exchange",
                "website": "http://www.twse.com.tw",
            },
            {
                "id": "BM_F_Bovespa",
                "name": "BM&F Bovespa",
                "website": "http://www.bmfbovespa.com.br/",
            },
        ];
    }
    StockService.prototype.getCompanies = function () {
        return this.stocks;
    };
    StockService.prototype.getCompany = function (id) {
        return this.stocks.filter(function (company) { return company.id === id; })[0];
    };
    StockService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], StockService);
    return StockService;
}());
exports.StockService = StockService;
//# sourceMappingURL=stock.service.js.map