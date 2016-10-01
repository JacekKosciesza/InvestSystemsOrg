import { Component, OnInit, Input } from '@angular/core';

import { MoatService } from './moat.service';
import { FinancialData } from './financial-data.model';

@Component({
    selector: 'big-five-numbers',
    templateUrl: 'build/+rule-one/moat/big-five-numbers.component.html'
})
export class BigFiveNumbersComponent implements OnInit {
    @Input() companySymbol: string;
    financialData: FinancialData[];

    constructor(public moatService: MoatService) {
        this.financialData = new Array<FinancialData>(); 
    }

    ngOnInit() {
        this.moatService.getFinancials(this.companySymbol).then(financialData => {
            this.financialData = financialData;
        });
    }
}