"use strict";
var ema_1 = require('./ema');
// http://investexcel.net/how-to-calculate-ema-in-excel/
var EMAService = (function () {
    function EMAService() {
        this.PARAM_1 = 10;
    }
    EMAService.prototype.calculate = function (stockPrices) {
        var _this = this;
        //debugger;
        var entries = stockPrices.map(function (sp) { return new ema_1.EMA(sp.date, sp.price); });
        entries.reduce(function (previousValue, currentValue, currentIndex) {
            var index = currentIndex + 1;
            currentValue.priceSum = previousValue.priceSum + currentValue.price;
            currentValue.priceAverage = currentValue.priceSum / index;
            // 10 Day EMA
            if (index === _this.PARAM_1) {
                currentValue.ema = currentValue.priceAverage;
            }
            else if (index > _this.PARAM_1) {
                currentValue.ema = currentValue.price * (2 / (_this.PARAM_1 + 1)) + previousValue.ema * (1 - 2 / (_this.PARAM_1 + 1));
            }
            return currentValue;
        }, new ema_1.EMA(new Date(1900, 1, 1), 0));
        return entries;
    };
    return EMAService;
}());
exports.EMAService = EMAService;
//# sourceMappingURL=ema.service.js.map