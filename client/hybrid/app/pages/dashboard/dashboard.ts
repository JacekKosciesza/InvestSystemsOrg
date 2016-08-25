import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import { SignInPage } from '../sign-in/sign-in';
import {TranslatePipe} from 'ng2-translate/ng2-translate';

@Component({
    templateUrl: 'build/pages/dashboard/dashboard.html',
    pipes: [TranslatePipe]
})
export class DashboardPage {
    constructor(public navCtrl: NavController) {
    }

    signIn() {
        this.navCtrl.push(SignInPage);
    }
}
