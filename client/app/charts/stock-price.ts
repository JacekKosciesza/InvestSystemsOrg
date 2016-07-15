export class StockPrice {
    constructor(public date: Date, public price: number) { }

    public toRow() {
        return [this.date, this.price];
    }
}