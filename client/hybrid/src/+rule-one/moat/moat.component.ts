import { Component, OnInit, Input } from '@angular/core';

import { MoatService } from './shared/moat.service';
import { Moat } from './shared/moat.model';

@Component({
    selector: 'moat',
    template: 
    `
        <h2>{{ '_rule.Moat' | translate }}</h2>
        <five-moats [fiveMoats]="moat.fiveMoats"></five-moats>
        <big-five [bigFive]="moat.bigFive"></big-five>
    `
})
export class MoatComponent implements OnInit {
    @Input() companySymbol: string;
    public moat: Moat;

    constructor(public moatService: MoatService) {
        this.moat = new Moat();
    }

    ngOnInit() {
        this.moatService.getMoat(this.companySymbol).then(moat => {
            this.moat = moat;
        });
    }
}