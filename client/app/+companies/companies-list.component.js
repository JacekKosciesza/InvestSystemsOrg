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
var platform_browser_1 = require('@angular/platform-browser');
var router_1 = require('@angular/router');
var card_1 = require('@angular2-material/card');
var companies_service_1 = require('./companies.service');
var CompaniesListComponent = (function () {
    function CompaniesListComponent(companiesService, router, titleService) {
        this.companiesService = companiesService;
        this.router = router;
        this.titleService = titleService;
    }
    CompaniesListComponent.prototype.ngOnInit = function () {
        this.companies = this.companiesService.getCompanies();
        this.titleService.setTitle('Companies');
    };
    CompaniesListComponent.prototype.gotoDetail = function (company) {
        var link = ['/companies/:symbol', { symbol: company.$key }];
        this.router.navigate(link);
    };
    CompaniesListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'companies-list',
            templateUrl: 'companies-list.component.html',
            styleUrls: ['companies-list.component.css'],
            directives: [card_1.MD_CARD_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [companies_service_1.CompaniesService, router_1.Router, platform_browser_1.Title])
    ], CompaniesListComponent);
    return CompaniesListComponent;
}());
exports.CompaniesListComponent = CompaniesListComponent;
//# sourceMappingURL=companies-list.component.js.map