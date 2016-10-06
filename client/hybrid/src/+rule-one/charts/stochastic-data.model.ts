export class StochasticData {
    // public date: Date;
    // public percentK: number;
    // public percentD: number;

    constructor(public date: Date, public percentK: number, public percentD: number) {
    }

    toRow() {
        return [this.date, this.percentK, this.percentD];
    }
}