"use strict";
// OHLC - Open, High, Low, Close
var OHLC = (function () {
    function OHLC(date, open, high, low, close) {
        this.date = date;
        this.open = open;
        this.high = high;
        this.low = low;
        this.close = close;
    }
    return OHLC;
}());
exports.OHLC = OHLC;
//# sourceMappingURL=ohlc.js.map