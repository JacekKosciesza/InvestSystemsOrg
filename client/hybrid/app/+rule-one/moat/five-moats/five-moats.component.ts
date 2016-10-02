import { Component, OnInit, Input } from '@angular/core';

import { FiveMoats } from './five-moats.model';

@Component({
    selector: 'five-moats',
    templateUrl: 'build/+rule-one/moat/five-moats/five-moats.component.html',
})
export class FiveMoatsComponent implements OnInit {
    @Input() fiveMoats: FiveMoats;

    constructor() {
    }
    
    ngOnInit() {  }
}