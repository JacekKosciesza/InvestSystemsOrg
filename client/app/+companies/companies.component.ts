import { Component, OnInit } from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { CompaniesService } from './companies.service'
import { CompaniesListComponent } from './companies-list.component'
import { CompanyDetailComponent } from './company-detail.component'

@Component({
  moduleId: module.id,
  selector: 'invsys-companies',
  templateUrl: 'companies.component.html',
  styleUrls: ['companies.component.css'],
  directives: [ROUTER_DIRECTIVES],
  providers: [CompaniesService]
})
@RouteConfig([
    {
        path: '/',
        name: 'CompaniesList',
        component: CompaniesListComponent,
        useAsDefault: true
    },
    {
        path: '/:symbol',
        name: 'CompaniesDetail',
        component: CompanyDetailComponent,
    },
])
export class CompaniesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}