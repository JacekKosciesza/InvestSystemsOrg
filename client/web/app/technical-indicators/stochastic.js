"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ohlc_1 = require('./ohlc');
var Stochastic = (function (_super) {
    __extends(Stochastic, _super);
    function Stochastic(date, open, high, low, close) {
        _super.call(this, date, open, high, low, close);
        this.date = date;
        this.open = open;
        this.high = high;
        this.low = low;
        this.close = close;
    }
    Stochastic.prototype.toRow = function () {
        return [this.date, this.percentK, this.percentD]; //, this.close];
    };
    return Stochastic;
}(ohlc_1.OHLC));
exports.Stochastic = Stochastic;
//# sourceMappingURL=stochastic.js.map