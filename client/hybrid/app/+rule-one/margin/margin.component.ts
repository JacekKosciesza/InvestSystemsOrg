import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'margin-of-safety',
    templateUrl: 'build/+rule-one/margin/margin.component.html'
})
export class MarginComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }

    futureValue(initialValue: number, rate: number, years: number): number {
        return initialValue * Math.pow(1 + rate, years);
    }

    initialValue(futureValue: number, rate: number, years: number): number {
        return futureValue / Math.pow(1 + rate, years);
    }
}