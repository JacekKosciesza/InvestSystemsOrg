import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'rule-one',
    templateUrl: 'rule-one.component.html'
})
export class RuleOneComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }
}