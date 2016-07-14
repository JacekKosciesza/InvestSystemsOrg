export class StockPrice {
    constructor(private date: Date, private price: number) { }

    public toRow() {
        return [this.date, this.price];
    }
}