import { Component } from '@angular/core';
import { IdentityService } from '../shared/identity.service';

@Component({
    templateUrl: 'identity-popover.component.html'
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