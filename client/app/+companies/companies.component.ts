import { Component, OnInit } from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { CompaniesService } from './companies.service'
import { CompaniesListComponent } from './companies-list.component'
import { CompanyCreateComponent } from './company-create.component'
import { CompanyDetailComponent } from './company-detail.component'
import { CompanyEditComponent } from './company-edit.component'

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
        path: '/create',
        name: 'CompaniesCreate',
        component: CompanyCreateComponent
    },
    {
        path: '/:symbol',
        name: 'CompaniesDetail',
        component: CompanyDetailComponent,
    },
    {
        path: '/:symbol/edit',
        name: 'CompaniesEdit',
        component: CompanyEditComponent,
    }
])
export class CompaniesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}