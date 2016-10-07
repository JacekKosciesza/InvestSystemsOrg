import { Component, OnInit, Input } from '@angular/core';

import { MarginService } from './margin.service';
import { Margin } from './margin.model';

@Component({
    selector: 'margin-of-safety',
    templateUrl: 'margin.component.html'
})
export class MarginComponent implements OnInit {
    @Input() companySymbol: string;
    public margin: Margin;

    constructor(private marginService: MarginService) {
        this.margin = new Margin();
    }

    ngOnInit() {
        this.marginService.getMargin(this.companySymbol).then(margin => {
            this.margin = margin;
        });
    }

    futureValue(initialValue: number, rate: number, years: number): number {
        return initialValue * Math.pow(1 + rate, years);
    }

    initialValue(futureValue: number, rate: number, years: number): number {
        return futureValue / Math.pow(1 + rate, years);
    }
}