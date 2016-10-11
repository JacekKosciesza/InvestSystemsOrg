import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'rule-one-rating',
    template:
    `
    <!--<ion-badge style="float:right;">75%</ion-badge>
    <ion-icon *ngIf="isWonderful" style="float:right; color:green;" name="thumbs-up"></ion-icon>
    <ion-icon *ngIf="isWonderful === false" style="float:right; color:red;" name="thumbs-down"></ion-icon>
    <ion-icon *ngIf="isWonderful === null || isWonderful === undefined" style="float:right; color:grey;" name="help"></ion-icon>-->

    <span *ngIf="isWonderful" style="color:green;">#1</span>
    <span *ngIf="isWonderful === false" style="color:red;">#1</span>
    <!--<span *ngIf="isWonderful === null || isWonderful === undefined" style="color:grey;">#1</span>-->

    <!--<ion-badge color="green" *ngIf="isWonderful">#1</ion-badge>
    <ion-badge color="red" *ngIf="isWonderful === false">#1</ion-badge>
    <ion-badge color="grey" *ngIf="isWonderful === null || isWonderful === undefined">#1</ion-badge>

    <span [ngSwitch]="getRandomInt(1,3)"> 
        <ion-badge *ngSwitchCase="1" color="green">Buy</ion-badge>
        <ion-badge *ngSwitchCase="2" color="orange">Hold</ion-badge>
        <ion-badge *ngSwitchCase="3" color="red">Sell</ion-badge>
    </span>-->
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

    getRandomInt(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min)) + min;
    }
}

