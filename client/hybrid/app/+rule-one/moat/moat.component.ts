import { Component, OnInit, Input } from '@angular/core';

import { FiveMoatsComponent } from './five-moats.component';
import { BigFiveNumbersComponent } from './big-five-numbers.component';
import { MoatService } from './moat.service';

@Component({
    selector: 'moat',
    templateUrl: 'build/+rule-one/moat/moat.component.html',
    providers: [MoatService],
    directives: [FiveMoatsComponent, BigFiveNumbersComponent]
})
export class MoatComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }
}