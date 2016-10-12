import { Component, OnInit, Input } from '@angular/core';

import { BigFiveAnnualComponent } from './big-five-annual/big-five-annual.component';
import { BigFiveGrowthComponent } from './big-five-growth/big-five-growth.component';

import { BigFive } from './shared/big-five.model';

@Component({
    selector: 'big-five',
    templateUrl: 'big-five.component.html' 
})
export class BigFiveComponent implements OnInit {
    @Input() bigFive: BigFive;

    constructor() {
        this.bigFive = new BigFive();
    }

    ngOnInit() { }
}