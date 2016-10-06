import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { SignInComponent } from '../+identity';

@Component({
    templateUrl: 'dashboard.component.html',
})
export class DashboardComponent {
    constructor(public navCtrl: NavController) {
    }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}
