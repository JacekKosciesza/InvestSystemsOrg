"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var stock_price_1 = require('../charts/stock-price');
var MACD = (function (_super) {
    __extends(MACD, _super);
    function MACD(date, price) {
        _super.call(this, date, price);
        this.priceSum = 0;
        this.macdSum = 0;
    }
    MACD.prototype.toRow = function () {
        return [this.date, this.macd, this.signal];
    };
    MACD.prototype.toHistogramRow = function () {
        return [this.date, this.histogram];
    };
    return MACD;
}(stock_price_1.StockPrice));
exports.MACD = MACD;
//# sourceMappingURL=macd.js.map