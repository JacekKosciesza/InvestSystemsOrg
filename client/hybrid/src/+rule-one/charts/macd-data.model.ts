export class MACDData {
    // public date: Date;
    // public macd: number;
    // public signal: number;

    constructor(public date: Date, public macd: number, public signal: number) {
    }

    toRow() {
        return [this.date, this.macd, this.signal];
    }
}