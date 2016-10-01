import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'big-five-numbers',
    templateUrl: 'build/+rule-one/moat/big-five-numbers.component.html'
})
export class BigFiveNumbersComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }
}