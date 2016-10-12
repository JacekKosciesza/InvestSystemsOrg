import { Component, OnInit, Input } from '@angular/core';

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