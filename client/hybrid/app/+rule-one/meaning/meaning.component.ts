import { Component, OnInit, Input } from '@angular/core';

import { MeaningStatementComponent } from './meaning-statement.component';
import { ThreeCirclesComponent } from './three-circles.component';
import { MeaningService } from './meaning.service';
import { Meaning } from './meaning.model';

@Component({
    selector: 'meaning-to-you',
    templateUrl: 'build/+rule-one/meaning/meaning.component.html',
    providers: [MeaningService],
    directives: [MeaningStatementComponent, ThreeCirclesComponent]
})
export class MeaningComponent implements OnInit {
    @Input() companySymbol: string;
    meaning: Meaning;

    constructor(public meaningService: MeaningService) {
        this.meaning = new Meaning(); 
    }

    ngOnInit() {
        this.meaningService.getMeaning(this.companySymbol, 'c6c746fd-e2da-4f3b-8417-6b7716421133').then(meaning => {
            this.meaning = meaning;
        });
    }
}