import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'margin-of-safety',
    templateUrl: 'build/+rule-one/margin/margin.component.html'
})
export class MarginComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }
}