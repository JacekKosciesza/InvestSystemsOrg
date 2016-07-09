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
var grid_list_1 = require('@angular2-material/grid-list');
var button_1 = require('@angular2-material/button');
var icon_1 = require('@angular2-material/icon/icon');
var stock_service_1 = require('./stock.service');
var StocksListComponent = (function () {
    function StocksListComponent(stockService, router, titleService) {
        this.stockService = stockService;
        this.router = router;
        this.titleService = titleService;
    }
    StocksListComponent.prototype.ngOnInit = function () {
        this.stocks = this.stockService.getStockExchanges();
        this.titleService.setTitle('Stock Exchanges');
    };
    StocksListComponent.prototype.gotoDetail = function (stock) {
        var link = ['/stock-exchanges', stock.id];
        this.router.navigate(link);
    };
    StocksListComponent.prototype.add = function () {
        var link = ['/stock-exchanges/create'];
        this.router.navigate(link);
    };
    StocksListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stocks-list',
            templateUrl: 'stocks-list.component.html',
            styleUrls: ['stocks-list.component.css'],
            directives: [grid_list_1.MD_GRID_LIST_DIRECTIVES, button_1.MD_BUTTON_DIRECTIVES, icon_1.MdIcon]
        }), 
        __metadata('design:paramtypes', [stock_service_1.StockService, router_1.Router, platform_browser_1.Title])
    ], StocksListComponent);
    return StocksListComponent;
}());
exports.StocksListComponent = StocksListComponent;
//# sourceMappingURL=stocks-list.component.js.map