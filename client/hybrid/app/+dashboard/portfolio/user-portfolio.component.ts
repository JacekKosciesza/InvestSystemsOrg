import { Component, OnInit } from '@angular/core';
import { TranslatePipe } from 'ng2-translate/ng2-translate';

@Component({
    selector: 'user-portfolio',
    templateUrl: 'build/+dashboard/portfolio/user-portfolio.component.html',
    pipes: [TranslatePipe]
})
export class UserPortfolioComponent implements OnInit {
    constructor() { }

    ngOnInit() { }
}