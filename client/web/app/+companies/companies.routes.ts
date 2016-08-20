import { RouterConfig } from '@angular/router';

import { CompaniesComponent } from './companies.component'
import { CompaniesListComponent } from './companies-list.component'
import { CompanyCreateComponent } from './company-create.component'
import { CompanyDetailComponent } from './company-detail.component'
import { CompanyEditComponent } from './company-edit.component'

export const CompaniesRoutes: RouterConfig = [
    {
        path: 'companies',
        component: CompaniesComponent,
        children: [
            {
                path: '',
                component: CompaniesListComponent
            },
            {
                path: 'create',
                component: CompanyCreateComponent
            },
            {
                path: ':symbol',
                component: CompanyDetailComponent
            },
            {
                path: ':symbol/edit',
                component: CompanyEditComponent
            }
        ]
    }
];