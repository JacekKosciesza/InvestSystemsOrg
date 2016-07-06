import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { CompaniesService } from './companies.service'

@Component({
  template: `
    <h1>Companies</h1>
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers: [CompaniesService]
})
export class CompaniesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}