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
var stock_service_1 = require('./stock.service');
var stocks_list_component_1 = require('./stocks-list.component');
var stock_detail_component_1 = require('./stock-detail.component');
var StocksComponent = (function () {
    function StocksComponent() {
    }
    StocksComponent.prototype.ngOnInit = function () {
    };
    StocksComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stock-exchanges',
            templateUrl: 'stocks.component.html',
            styleUrls: ['stocks.component.css'],
            directives: [router_deprecated_1.ROUTER_DIRECTIVES],
            providers: [stock_service_1.StockService]
        }),
        router_deprecated_1.RouteConfig([
            {
                path: '/',
                name: 'StocksList',
                component: stocks_list_component_1.StocksListComponent,
                useAsDefault: true
            },
            {
                path: '/:id',
                name: 'StockDetail',
                component: stock_detail_component_1.StockDetailComponent,
            },
        ]), 
        __metadata('design:paramtypes', [])
    ], StocksComponent);
    return StocksComponent;
}());
exports.StocksComponent = StocksComponent;
//# sourceMappingURL=stocks.component.js.map