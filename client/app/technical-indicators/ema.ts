import { StockPrice } from '../charts/stock-price'

export class EMA extends StockPrice {
    constructor(date: Date, price: number) {
        super(date, price);
        this.priceSum = 0;
    }

    priceSum: number;
    priceAverage: number;
    ema: number;

    toRow() {
        return [this.date, this.price, this.ema];
    }
}