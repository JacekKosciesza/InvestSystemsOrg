"use strict";
var companies_component_1 = require('./companies.component');
var companies_list_component_1 = require('./companies-list.component');
var company_create_component_1 = require('./company-create.component');
var company_detail_component_1 = require('./company-detail.component');
var company_edit_component_1 = require('./company-edit.component');
exports.CompaniesRoutes = [
    {
        path: 'companies',
        component: companies_component_1.CompaniesComponent,
        children: [
            {
                path: '',
                component: companies_list_component_1.CompaniesListComponent
            },
            {
                path: 'create',
                component: company_create_component_1.CompanyCreateComponent
            },
            {
                path: ':symbol',
                component: company_detail_component_1.CompanyDetailComponent
            },
            {
                path: ':symbol/edit',
                component: company_edit_component_1.CompanyEditComponent
            }
        ]
    }
];
//# sourceMappingURL=companies.routes.js.map