import { Component } from '@angular/core';
import { Platform, NavParams, ViewController } from 'ionic-angular';
import { IdentityService } from '../shared/identity.service';

@Component({
    selector: 'sign-in',
    templateUrl: 'sign-in.component.html'
})
export class SignInComponent {
    constructor(
        public platform: Platform,
        public params: NavParams,
        public viewCtrl: ViewController,
        private identityService: IdentityService) {
    }

    signIn(username: string, password: string) {
        this.identityService.getToken(username, password).then(token => {
            this.dismiss();
        })
    }

    dismiss() {
        this.viewCtrl.dismiss();
    }
}
