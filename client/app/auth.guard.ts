import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AngularFire } from 'angularfire2';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private af: AngularFire, private router: Router) {}

  canActivate() {
    // debugger;
    // if (this.af.auth) { return true; }
    // this.router.navigate(['/login']);
    // return false;

    return true;
  }
}