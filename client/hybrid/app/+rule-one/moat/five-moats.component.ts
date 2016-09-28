import { Component, OnInit, Input } from '@angular/core';

import { FiveMoatsService } from './five-moats.service';
import { Moat } from './moat.model';

@Component({
    selector: 'five-moats',
    templateUrl: 'build/+rule-one/moat/five-moats.component.html',
    providers: [FiveMoatsService]

})
export class FiveMoatsComponent implements OnInit {
    @Input() companySymbol: string;
    moat: Moat;

    constructor(public fiveMoatsService: FiveMoatsService) {
        this.moat = new Moat();
    }

    ngOnInit() {
        this.fiveMoatsService.getMoat(this.companySymbol).then(moat => {
            this.moat = moat;
        });
    }
}