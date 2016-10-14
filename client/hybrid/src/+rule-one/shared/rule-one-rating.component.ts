import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'rule-one-rating',
    templateUrl: 'rule-one-rating.component.html'
})
export class RuleOneRatingComponent implements OnInit {
    @Input() isWonderful: boolean;
    public margin: number;
    public threeTools: any;
    
    constructor() {
        this.margin = this.getRandomInt(1,3);
        this.threeTools = {
            buy: this.getRandomInt(1,2) === 1,
            signal: this.getRandomInt(1,3) 
        }
    }

    ngOnInit() { }

    getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}

