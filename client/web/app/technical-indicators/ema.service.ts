import { StockPrice } from '../charts/stock-price'
import { EMA } from './ema'

// http://investexcel.net/how-to-calculate-ema-in-excel/
export class EMAService {
    PARAM_1: number = 10;
    calculate(stockPrices: StockPrice[]) : EMA[] {
        //debugger;
        let entries = stockPrices.map(sp => new EMA(sp.date, sp.price));
        entries.reduce((previousValue, currentValue, currentIndex) => {
            let index = currentIndex + 1;
            currentValue.priceSum = previousValue.priceSum + currentValue.price;
            currentValue.priceAverage = currentValue.priceSum / index;
            
            // 10 Day EMA
            if (index === this.PARAM_1) {
                currentValue.ema = currentValue.priceAverage;
            } else if (index > this.PARAM_1) {
                currentValue.ema = currentValue.price * (2/(this.PARAM_1 + 1)) + previousValue.ema * (1 - 2/(this.PARAM_1 + 1));
            }

            return currentValue;
        }, new EMA(new Date(1900, 1, 1), 0));

        return entries;
    }
}

