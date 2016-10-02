import { Component, OnInit, Input } from '@angular/core';

import { FiveMoatsComponent } from './five-moats/five-moats.component';
import { BigFiveComponent } from './big-five/big-five.component';
import { MoatService } from './shared/moat.service';
import { Moat } from './shared/moat.model';

@Component({
    selector: 'moat',
    template: 
    `
        <five-moats [fiveMoats]="moat.fiveMoats"></five-moats>
        <big-five [bigFive]="moat.bigFive"></big-five>
    `,
    providers: [MoatService],
    directives: [FiveMoatsComponent, BigFiveComponent]
})
export class MoatComponent implements OnInit {
    @Input() companySymbol: string;
    moat: Moat;

    constructor(public moatService: MoatService) {
        this.moat = new Moat();
    }

    ngOnInit() {
        this.moatService.getMoat(this.companySymbol).then(moat => {
            this.moat = moat;
        });
    }
}