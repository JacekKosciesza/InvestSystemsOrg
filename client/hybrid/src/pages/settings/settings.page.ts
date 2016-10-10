import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { SignInComponent } from '../../+identity';

import { Settings } from '../../shared';

@Component({
    selector: 'settings-page',
    templateUrl: 'settings.page.html'
})
export class SettingsPage {
    constructor(public settings: Settings, public navCtrl: NavController) {
    }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}
