import { OHLC } from './ohlc'

export class Stochastic extends OHLC {
    constructor (public date: Date, public open: number, public high: number, public low: number, public close: number) {
        super(date, open, high, low, close);
    }

    highestHigh: number;
    lowestLow: number;
    percentK: number;
    percentD: number;

    toRow() {
        return [this.date, this.percentK, this.percentD]; //, this.close];
    }
}