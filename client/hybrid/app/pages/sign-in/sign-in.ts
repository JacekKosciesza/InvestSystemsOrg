import {Component} from '@angular/core';
import {TranslatePipe} from 'ng2-translate/ng2-translate';

@Component({
    templateUrl: 'build/pages/sign-in/sign-in.html',
    pipes: [TranslatePipe]
})
export class SignInPage {
    constructor() {

    }
}
