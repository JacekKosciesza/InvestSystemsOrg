export class EMAData {
    // public date: Date;
    // public price: number;
    // public ema: number;

    constructor(public date: Date, public price: number, public ema: number) {
    }

    toRow() {
        return [this.date, this.price, this.ema];
    }
}