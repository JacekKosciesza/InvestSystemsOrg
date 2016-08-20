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
var companies_service_1 = require('../+companies/companies.service');
var portfolio_component_1 = require('./portfolio.component');
var portfolio_service_1 = require('./portfolio.service');
var watch_list_component_1 = require('./watch-list.component');
var watch_list_service_1 = require('./watch-list.service');
var DashboardComponent = (function () {
    function DashboardComponent() {
    }
    DashboardComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            templateUrl: 'dashboard.component.html',
            directives: [portfolio_component_1.PortfolioComponent, watch_list_component_1.WatchListComponent],
            providers: [companies_service_1.CompaniesService, portfolio_service_1.PortfolioService, watch_list_service_1.WatchListService] // TODO: move CompaniesService level up?
        }), 
        __metadata('design:paramtypes', [])
    ], DashboardComponent);
    return DashboardComponent;
}());
exports.DashboardComponent = DashboardComponent;
//# sourceMappingURL=dashboard.component.js.map