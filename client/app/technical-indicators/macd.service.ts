import { StockPrice } from '../charts/stock-price'
import { MACD } from './macd'

// // http://investexcel.net/how-to-calculate-macd-in-excel/
export class MACDService {
    PARAM_1: number = 12;
    PARAM_2: number = 26;
    PARAM_3: number = 9;
    calculate(stockPrices: StockPrice[]) : MACD[] {
        //debugger;
        let entries = stockPrices.map(sp => new MACD(sp.date, sp.price));
        entries.reduce((previousValue, currentValue, currentIndex) => {
            let index = currentIndex + 1;
            currentValue.priceSum = previousValue.priceSum + currentValue.price;
            currentValue.priceAverage = currentValue.priceSum / index;
            
            // 12 Day EMA
            if (index === this.PARAM_1) {
                currentValue.ema12day = currentValue.priceAverage;
            } else if (index > this.PARAM_1) {
                currentValue.ema12day = currentValue.price * (2/(this.PARAM_1 + 1)) + previousValue.ema12day * (1 - 2/(this.PARAM_1 + 1));
            }

            // 26 Day EMA
            if (index === this.PARAM_2) {
                currentValue.ema26day = currentValue.priceAverage;
            } else if (index > this.PARAM_2) {
                currentValue.ema26day = currentValue.price * (2/(this.PARAM_2 + 1)) + previousValue.ema26day * (1 - 2/(this.PARAM_2 + 1));
            }

            // MCDA
            if (index >= this.PARAM_2) {
                currentValue.macd = currentValue.ema12day - currentValue.ema26day;
                currentValue.macdSum = previousValue.macdSum + currentValue.macd;
                currentValue.macdAverage = currentValue.macdSum / (index - this.PARAM_2 + 1);
            }

            // Signal
            if (index === (this.PARAM_2 + this.PARAM_3 - 1)) {
                currentValue.signal = currentValue.macdAverage;
            } else if (index > (this.PARAM_2 + this.PARAM_3 - 1)) {
                currentValue.signal = currentValue.macd * (2/(this.PARAM_3 + 1)) + previousValue.signal * (1 - 2/(this.PARAM_3 + 1));
            }

            // Histogram
            if (index >= (this.PARAM_2 + this.PARAM_3 - 1)) {
                currentValue.histogram = currentValue.macd - currentValue.signal;
            }

            return currentValue;
        }, new MACD(new Date(1900, 1, 1), 0));

        return entries;
    }
}

