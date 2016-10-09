import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { SignInComponent } from '../../+identity';

@Component({
    selector: 'settings-page',
    templateUrl: 'settings.page.html'
})
export class SettingsPage {
    settings: any;

    constructor(public navCtrl: NavController) {
        this.settings = {theme:'light'};
    }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}
