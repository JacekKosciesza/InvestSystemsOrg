import { OHLC } from './ohlc'
import { Stochastic } from './stochastic'

// http://investexcel.net/how-to-calculate-the-stochastic-oscillator/
export class StochasticService {
    PARAM_1: number = 14;
    PARAM_2: number = 5; // 3


    calculate(ohlcData: OHLC[]): Stochastic[] {
        //debugger;
        let entries = ohlcData.map(x => new Stochastic(x.date, x.open, x.high, x.low, x.close));
        entries.reduce((previousValue, currentValue, currentIndex, array) => {
            let index = currentIndex + 1;

            
            if (index >= this.PARAM_1) {
                // Highest high & Lowest low
                let subarray = array.slice(index - this.PARAM_1, index); 
                currentValue.highestHigh = Math.max(...subarray.map(x => x.high));
                currentValue.lowestLow = Math.min(...subarray.map(x => x.low));

                // %K
                currentValue.percentK = (currentValue.close -  currentValue.lowestLow) / (currentValue.highestHigh - currentValue.lowestLow) * 100;
            }

            // %D
            if (index >= this.PARAM_1 + this.PARAM_2 - 1) {
                let sum = 0;
                for (let i = this.PARAM_2 - 1; i >= 0; i--) {
                    sum += array[index - i - 1].percentK;
                }
                currentValue.percentD = sum / this.PARAM_2;  
            }

            return currentValue;
        }, new Stochastic(new Date(1900), 0, 0, 0, 0));

        return entries;
    }
}

