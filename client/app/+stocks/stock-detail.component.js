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
var stock_service_1 = require('./stock.service');
var StockDetailComponent = (function () {
    function StockDetailComponent(companiesService, route, titleService) {
        this.companiesService = companiesService;
        this.route = route;
        this.titleService = titleService;
    }
    StockDetailComponent.prototype.ngOnInit = function () {
        var symbol = this.route.snapshot.params['symbol'];
        if (symbol) {
            this.stock = this.companiesService.getCompany(symbol);
            this.titleService.setTitle(this.stock.name);
        }
    };
    StockDetailComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stock-detail',
            templateUrl: 'stock-detail.component.html',
            styleUrls: ['stock-detail.component.css']
        }), 
        __metadata('design:paramtypes', [stock_service_1.StockService, router_1.ActivatedRoute, platform_browser_1.Title])
    ], StockDetailComponent);
    return StockDetailComponent;
}());
exports.StockDetailComponent = StockDetailComponent;
//# sourceMappingURL=stock-detail.component.js.map