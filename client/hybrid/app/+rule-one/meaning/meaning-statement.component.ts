import { Component, OnInit, Input } from '@angular/core';

import { Meaning } from './meaning.model';

@Component({
    selector: 'meaning-statement',
    templateUrl: 'build/+rule-one/meaning/meaning-statement.component.html'
})
export class MeaningStatementComponent implements OnInit {
    @Input() meaning: Meaning;

    constructor() { }

    ngOnInit() { }
}