import { Component, OnInit, Input } from '@angular/core';

import { BigFiveAnnual } from './big-five-annual.model';

@Component({
    selector: 'big-five-annual',
    templateUrl: 'big-five-annual.component.html'
})
export class BigFiveAnnualComponent implements OnInit {
    @Input() bigFiveAnnual: Array<BigFiveAnnual>;

    constructor() { }

    ngOnInit() { }

    // http://pages.uoregon.edu/rgp/PPPM613/class8a.htm
    growthRate(future: number, past: number, years: number): number {
        let growthRate = Math.pow(future/past, 1/years) - 1; 
        return Math.round(growthRate * 100);
    }
}