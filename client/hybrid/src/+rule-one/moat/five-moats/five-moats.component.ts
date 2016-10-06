import { Component, OnInit, Input } from '@angular/core';

import { FiveMoats } from './five-moats.model';

@Component({
    selector: 'five-moats',
    templateUrl: 'five-moats.component.html',
})
export class FiveMoatsComponent implements OnInit {
    @Input() fiveMoats: FiveMoats;

    constructor() {
    }
    
    ngOnInit() {  }
}