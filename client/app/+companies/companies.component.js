"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_deprecated_1 = require('@angular/router-deprecated');
var companies_service_1 = require('./companies.service');
var companies_list_component_1 = require('./companies-list.component');
var company_detail_component_1 = require('./company-detail.component');
var CompaniesComponent = (function () {
    function CompaniesComponent() {
    }
    CompaniesComponent.prototype.ngOnInit = function () {
    };
    CompaniesComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'invsys-companies',
            templateUrl: 'companies.component.html',
            styleUrls: ['companies.component.css'],
            directives: [router_deprecated_1.ROUTER_DIRECTIVES],
            providers: [companies_service_1.CompaniesService]
        }),
        router_deprecated_1.RouteConfig([
            {
                path: '/',
                name: 'CompaniesList',
                component: companies_list_component_1.CompaniesListComponent,
                useAsDefault: true
            },
            {
                path: '/:symbol',
                name: 'CompaniesDetail',
                component: company_detail_component_1.CompanyDetailComponent,
            },
        ]), 
        __metadata('design:paramtypes', [])
    ], CompaniesComponent);
    return CompaniesComponent;
}());
exports.CompaniesComponent = CompaniesComponent;
//# sourceMappingURL=companies.component.js.map