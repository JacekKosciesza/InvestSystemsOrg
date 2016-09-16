import { Component } from '@angular/core';
import { ModalController, Platform, NavParams, ViewController } from 'ionic-angular';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { IdentityService } from '../shared'

@Component({
    templateUrl: 'build/+identity/sign-in/sign-in.component.html',
    pipes: [TranslatePipe]
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
            console.log(token);
            this.dismiss();
        })
    }

    dismiss() {
        this.viewCtrl.dismiss();
    }
}
