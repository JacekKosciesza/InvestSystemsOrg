import { FiveMoats } from '../five-moats/five-moats.model';
import { BigFive } from '../big-five/shared/big-five.model';

export class Moat {
    public fiveMoats: FiveMoats;
    public bigFive: BigFive

    constructor() {
        this.fiveMoats = new FiveMoats();
        this.bigFive = new BigFive();
    }
}