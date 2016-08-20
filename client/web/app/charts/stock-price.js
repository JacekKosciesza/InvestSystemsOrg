"use strict";
var StockPrice = (function () {
    function StockPrice(date, price) {
        this.date = date;
        this.price = price;
    }
    StockPrice.prototype.toRow = function () {
        return [this.date, this.price];
    };
    return StockPrice;
}());
exports.StockPrice = StockPrice;
//# sourceMappingURL=stock-price.js.map