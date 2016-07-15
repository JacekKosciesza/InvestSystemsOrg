import { StockPrice } from '../charts/stock-price'

export class MACDEntry extends StockPrice {
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
}

export class MACD {
    PARAM_1: number = 12;
    PARAM_2: number = 26;
    PARAM_3: number = 9;
    calculate(stockPrices: StockPrice[]) : MACDEntry[] {
        let mcdaEntries: MACDEntry[] = [];
        debugger;
        let entries = stockPrices.map(sp => new MACDEntry(sp.date, sp.price));
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
        }, new MACDEntry(new Date(1900, 1, 1), 0));

        return entries;
    }
}

export const MCDA_TEST_DATA = [
    new StockPrice(new Date('2/19/2013'), 459.99),
    new StockPrice(new Date('2/20/2013'), 448.85),
    new StockPrice(new Date('2/21/2013'), 446.06),
    new StockPrice(new Date('2/22/2013'), 450.81),
    new StockPrice(new Date('2/25/2013'), 442.8),
    new StockPrice(new Date('2/26/2013'), 448.97),
    new StockPrice(new Date('2/27/2013'), 444.57),
    new StockPrice(new Date('2/28/2013'), 441.4),
    new StockPrice(new Date('3/1/2013'), 430.47),
    new StockPrice(new Date('3/4/2013'), 420.05),
    new StockPrice(new Date('3/5/2013'), 431.14),
    new StockPrice(new Date('3/6/2013'), 425.66),
    new StockPrice(new Date('3/7/2013'), 430.58),
    new StockPrice(new Date('3/8/2013'), 431.72),
    new StockPrice(new Date('3/11/2013'), 437.87),
    new StockPrice(new Date('3/12/2013'), 428.43),
    new StockPrice(new Date('3/13/2013'), 428.35),
    new StockPrice(new Date('3/14/2013'), 432.5),
    new StockPrice(new Date('3/15/2013'), 443.66),
    new StockPrice(new Date('3/18/2013'), 455.72),
    new StockPrice(new Date('3/19/2013'), 454.49),
    new StockPrice(new Date('3/20/2013'), 452.08),
    new StockPrice(new Date('3/21/2013'), 452.73),
    new StockPrice(new Date('3/22/2013'), 461.91),
    new StockPrice(new Date('3/25/2013'), 463.58),
    new StockPrice(new Date('3/26/2013'), 461.14),
    new StockPrice(new Date('3/27/2013'), 452.08),
    new StockPrice(new Date('3/28/2013'), 442.66),
    new StockPrice(new Date('4/1/2013'), 428.91),
    new StockPrice(new Date('4/2/2013'), 429.79),
    new StockPrice(new Date('4/3/2013'), 431.99),
    new StockPrice(new Date('4/4/2013'), 427.72),
    new StockPrice(new Date('4/5/2013'), 423.2),
    new StockPrice(new Date('4/8/2013'), 426.21),
    new StockPrice(new Date('4/9/2013'), 426.98),
    new StockPrice(new Date('4/10/2013'), 435.69),
    new StockPrice(new Date('4/11/2013'), 434.33),
    new StockPrice(new Date('4/12/2013'), 429.8),
    new StockPrice(new Date('4/15/2013'), 419.85),
    new StockPrice(new Date('4/16/2013'), 426.24),
    new StockPrice(new Date('4/17/2013'), 402.8),
    new StockPrice(new Date('4/18/2013'), 392.05),
    new StockPrice(new Date('4/19/2013'), 390.53),
    new StockPrice(new Date('4/22/2013'), 398.67),
    new StockPrice(new Date('4/23/2013'), 406.13),
    new StockPrice(new Date('4/24/2013'), 405.46),
    new StockPrice(new Date('4/25/2013'), 408.38),
    new StockPrice(new Date('4/26/2013'), 417.2),
    new StockPrice(new Date('4/29/2013'), 430.12),
    new StockPrice(new Date('4/30/2013'), 442.78),
    new StockPrice(new Date('5/1/2013'), 439.29),
    new StockPrice(new Date('5/2/2013'), 445.52),
    new StockPrice(new Date('5/3/2013'), 449.98),
    new StockPrice(new Date('5/6/2013'), 460.71),
    new StockPrice(new Date('5/7/2013'), 458.66),
    new StockPrice(new Date('5/8/2013'), 463.84),
    new StockPrice(new Date('5/9/2013'), 456.77),
    new StockPrice(new Date('5/10/2013'), 452.97),
    new StockPrice(new Date('5/13/2013'), 454.74),
    new StockPrice(new Date('5/14/2013'), 443.86),
    new StockPrice(new Date('5/15/2013'), 428.85),
    new StockPrice(new Date('5/16/2013'), 434.58),
    new StockPrice(new Date('5/17/2013'), 433.26),
    new StockPrice(new Date('5/20/2013'), 442.93),
    new StockPrice(new Date('5/21/2013'), 439.66),
    new StockPrice(new Date('5/22/2013'), 441.35)
]