import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { LeadersService } from './leaders.service';


@Component({
  template: `
    <h1>Leaders</h1>
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers: [LeadersService]
})
export class LeadersComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}