"use strict";
var macd_1 = require('./macd');
// // http://investexcel.net/how-to-calculate-macd-in-excel/
var MACDService = (function () {
    function MACDService() {
        this.PARAM_1 = 12;
        this.PARAM_2 = 26;
        this.PARAM_3 = 9;
    }
    MACDService.prototype.calculate = function (stockPrices) {
        var _this = this;
        //debugger;
        var entries = stockPrices.map(function (sp) { return new macd_1.MACD(sp.date, sp.price); });
        entries.reduce(function (previousValue, currentValue, currentIndex) {
            var index = currentIndex + 1;
            currentValue.priceSum = previousValue.priceSum + currentValue.price;
            currentValue.priceAverage = currentValue.priceSum / index;
            // 12 Day EMA
            if (index === _this.PARAM_1) {
                currentValue.ema12day = currentValue.priceAverage;
            }
            else if (index > _this.PARAM_1) {
                currentValue.ema12day = currentValue.price * (2 / (_this.PARAM_1 + 1)) + previousValue.ema12day * (1 - 2 / (_this.PARAM_1 + 1));
            }
            // 26 Day EMA
            if (index === _this.PARAM_2) {
                currentValue.ema26day = currentValue.priceAverage;
            }
            else if (index > _this.PARAM_2) {
                currentValue.ema26day = currentValue.price * (2 / (_this.PARAM_2 + 1)) + previousValue.ema26day * (1 - 2 / (_this.PARAM_2 + 1));
            }
            // MCDA
            if (index >= _this.PARAM_2) {
                currentValue.macd = currentValue.ema12day - currentValue.ema26day;
                currentValue.macdSum = previousValue.macdSum + currentValue.macd;
                currentValue.macdAverage = currentValue.macdSum / (index - _this.PARAM_2 + 1);
            }
            // Signal
            if (index === (_this.PARAM_2 + _this.PARAM_3 - 1)) {
                currentValue.signal = currentValue.macdAverage;
            }
            else if (index > (_this.PARAM_2 + _this.PARAM_3 - 1)) {
                currentValue.signal = currentValue.macd * (2 / (_this.PARAM_3 + 1)) + previousValue.signal * (1 - 2 / (_this.PARAM_3 + 1));
            }
            // Histogram
            if (index >= (_this.PARAM_2 + _this.PARAM_3 - 1)) {
                currentValue.histogram = currentValue.macd - currentValue.signal;
            }
            return currentValue;
        }, new macd_1.MACD(new Date(1900, 1, 1), 0));
        return entries;
    };
    return MACDService;
}());
exports.MACDService = MACDService;
//# sourceMappingURL=macd.service.js.map