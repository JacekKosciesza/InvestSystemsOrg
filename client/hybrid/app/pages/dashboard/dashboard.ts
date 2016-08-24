import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import { SignInPage } from '../sign-in/sign-in'

@Component({
    templateUrl: 'build/pages/dashboard/dashboard.html'
})
export class DashboardPage {
    constructor(public navCtrl: NavController) {
    }

    signIn() {
        this.navCtrl.push(SignInPage);
    }
}
