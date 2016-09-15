import {Component} from '@angular/core';
import {TranslatePipe} from 'ng2-translate/ng2-translate';

@Component({
    templateUrl: 'build/+identity/sign-in/sign-in.component.html',
    pipes: [TranslatePipe]
})
export class SignInComponent {
    constructor() {

    }
}
