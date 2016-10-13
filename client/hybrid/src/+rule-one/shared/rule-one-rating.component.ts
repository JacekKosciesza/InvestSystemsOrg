import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'rule-one-rating',
    templateUrl: 'rule-one-rating.component.html'
})
export class RuleOneRatingComponent implements OnInit {
    @Input() isWonderful: boolean;
    public currentPriceGood: number;
    public currentPriceTrend: number;
    
    constructor() {
        this.currentPriceGood = this.getRandomInt(1,3);
        this.currentPriceTrend = this.getRandomInt(1,2);
    }

    ngOnInit() { }

    getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}

