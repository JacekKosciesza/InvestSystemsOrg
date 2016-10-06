import { Component, OnInit, Input } from '@angular/core';

import { BigFiveGrowthRate } from './big-five-growth-rate.model';

@Component({
    selector: 'big-five-growth',
    templateUrl: 'big-five-growth.component.html'
})
export class BigFiveGrowthComponent implements OnInit {
    @Input() bigFiveGrowthRates: Array<BigFiveGrowthRate>;

    constructor() { }

    ngOnInit() { }
}