"use strict";
var stochastic_1 = require('./stochastic');
// http://investexcel.net/how-to-calculate-the-stochastic-oscillator/
var StochasticService = (function () {
    function StochasticService() {
        this.PARAM_1 = 14;
        this.PARAM_2 = 5; // 3
    }
    StochasticService.prototype.calculate = function (ohlcData) {
        var _this = this;
        //debugger;
        var entries = ohlcData.map(function (x) { return new stochastic_1.Stochastic(x.date, x.open, x.high, x.low, x.close); });
        entries.reduce(function (previousValue, currentValue, currentIndex, array) {
            var index = currentIndex + 1;
            if (index >= _this.PARAM_1) {
                // Highest high & Lowest low
                var subarray = array.slice(index - _this.PARAM_1, index);
                currentValue.highestHigh = Math.max.apply(Math, subarray.map(function (x) { return x.high; }));
                currentValue.lowestLow = Math.min.apply(Math, subarray.map(function (x) { return x.low; }));
                // %K
                currentValue.percentK = (currentValue.close - currentValue.lowestLow) / (currentValue.highestHigh - currentValue.lowestLow) * 100;
            }
            // %D
            if (index >= _this.PARAM_1 + _this.PARAM_2 - 1) {
                var sum = 0;
                for (var i = _this.PARAM_2 - 1; i >= 0; i--) {
                    sum += array[index - i - 1].percentK;
                }
                currentValue.percentD = sum / _this.PARAM_2;
            }
            return currentValue;
        }, new stochastic_1.Stochastic(new Date(1900), 0, 0, 0, 0));
        return entries;
    };
    return StochasticService;
}());
exports.StochasticService = StochasticService;
//# sourceMappingURL=stochastic.service.js.map