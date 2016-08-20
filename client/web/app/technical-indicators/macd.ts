import { StockPrice } from '../charts/stock-price'

export class MACD extends StockPrice {
    constructor(date: Date, price: number) {
        super(date, price);
        this.priceSum = 0;
        this.macdSum = 0;
    }

    priceSum: number;
    priceAverage: number;
    ema12day: number;
    ema26day: number;
    macd: number;
    macdSum: number;
    macdAverage: number;
    signal: number;
    histogram: number;

    toRow() {
        return [this.date, this.macd, this.signal];
    }

    toHistogramRow() {
        return [this.date, this.histogram];
    }
}