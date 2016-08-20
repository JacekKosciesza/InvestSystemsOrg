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
var watch_list_service_1 = require('./watch-list.service');
var companies_list_component_1 = require('../+companies/companies-list.component');
var WatchListComponent = (function () {
    function WatchListComponent(watchListService) {
        this.watchListService = watchListService;
        this.user = 'jacek-kosciesza'; // TOOD: get it from identidy service
    }
    WatchListComponent.prototype.ngOnInit = function () {
        this.companies = this.watchListService.getCompanies(this.user);
    };
    WatchListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'watch-list',
            templateUrl: 'watch-list.component.html',
            directives: [companies_list_component_1.CompaniesListComponent]
        }), 
        __metadata('design:paramtypes', [watch_list_service_1.WatchListService])
    ], WatchListComponent);
    return WatchListComponent;
}());
exports.WatchListComponent = WatchListComponent;
//# sourceMappingURL=watch-list.component.js.map