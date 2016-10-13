import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'dashboard-hint',
    templateUrl: 'dashboard-hint.component.html'
})
export class DashboardHintComponent implements OnInit {
    public watchlistOrPortfolio: number;
    
    constructor() {
        this.watchlistOrPortfolio = this.getRandomInt(1,2);
    }

    ngOnInit() { }

    getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}