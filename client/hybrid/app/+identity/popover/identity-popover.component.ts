import { Component } from '@angular/core';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { IdentityService } from '../';

@Component({
    templateUrl: 'build/+identity/popover/identity-popover.component.html',
    pipes: [TranslatePipe]
})
export class IdentityPopoverComponent {
    constructor(public identityService: IdentityService) { }

    profile() {

    }

    logout() {
        console.log('logout');
        this.identityService.token = null;
    }
}