import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'rule-one-rating',
    template:
    `
    <!--<ion-badge style="float:right;">75%</ion-badge>-->
    <ion-icon *ngIf="isWonderful" style="float:right; color:green;" name="thumbs-up"></ion-icon>
    <ion-icon *ngIf="isWonderful === false" style="float:right; color:red;" name="thumbs-down"></ion-icon>
    <ion-icon *ngIf="isWonderful === null || isWonderful === undefined" style="float:right; color:grey;" name="help"></ion-icon>
    `,
    styles: [`
        :host {
            display:inline-block;
        }
    `]
})
export class RuleOneRatingComponent implements OnInit {
    @Input() isWonderful: boolean;
    constructor() { }

    ngOnInit() { }
}

