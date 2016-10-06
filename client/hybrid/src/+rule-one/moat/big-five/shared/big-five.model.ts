import { BigFiveAnnual } from '../big-five-annual/big-five-annual.model';
import { BigFiveGrowthRate } from '../big-five-growth/big-five-growth-rate.model';

export class BigFive {
    public bigFiveAnnual: Array<BigFiveAnnual>;
    public bigFiveGrowthRates: Array<BigFiveGrowthRate>;

    constructor() {
        this.bigFiveAnnual = new Array<BigFiveAnnual>();
        this.bigFiveGrowthRates = new Array<BigFiveGrowthRate>();
    }
}