"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var stock_price_1 = require('../charts/stock-price');
var EMA = (function (_super) {
    __extends(EMA, _super);
    function EMA(date, price) {
        _super.call(this, date, price);
        this.priceSum = 0;
    }
    EMA.prototype.toRow = function () {
        return [this.date, this.price, this.ema];
    };
    return EMA;
}(stock_price_1.StockPrice));
exports.EMA = EMA;
//# sourceMappingURL=ema.js.map