import { Component, OnInit, Input } from '@angular/core';

import { MoatService } from './moat.service';
import { Moat } from './moat.model';

@Component({
    selector: 'five-moats',
    templateUrl: 'build/+rule-one/moat/five-moats.component.html',
})
export class FiveMoatsComponent implements OnInit {
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