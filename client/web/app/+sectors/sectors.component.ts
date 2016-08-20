import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { SectorsService } from './sectors.service';


@Component({
  template: `
    <h1>Sectors</h1>
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers: [SectorsService]
})
export class SectorsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}