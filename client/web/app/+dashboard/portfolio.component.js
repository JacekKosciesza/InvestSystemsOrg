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
var portfolio_service_1 = require('./portfolio.service');
var companies_list_component_1 = require('../+companies/companies-list.component');
var PortfolioComponent = (function () {
    function PortfolioComponent(portfolioService) {
        this.portfolioService = portfolioService;
        this.user = 'jacek-kosciesza'; // TOOD: get it from identidy service
    }
    PortfolioComponent.prototype.ngOnInit = function () {
        this.companies = this.portfolioService.getCompanies(this.user);
    };
    PortfolioComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-portfolio',
            templateUrl: 'portfolio.component.html',
            directives: [companies_list_component_1.CompaniesListComponent]
        }), 
        __metadata('design:paramtypes', [portfolio_service_1.PortfolioService])
    ], PortfolioComponent);
    return PortfolioComponent;
}());
exports.PortfolioComponent = PortfolioComponent;
//# sourceMappingURL=portfolio.component.js.map