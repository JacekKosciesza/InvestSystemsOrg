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
var button_1 = require('@angular2-material/button');
var icon_1 = require('@angular2-material/icon/icon');
var stock_service_1 = require('./stock.service');
var StockDetailComponent = (function () {
    function StockDetailComponent(stockService, route, router, titleService) {
        this.stockService = stockService;
        this.route = route;
        this.router = router;
        this.titleService = titleService;
    }
    StockDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.routeParams = this.route.params.subscribe(function (params) {
            var id = params['id'];
            if (id) {
                _this.stock = _this.stockService.getStockExchange(id);
                _this.stock.subscribe(function (stock) {
                    _this.titleService.setTitle(stock.name);
                });
            }
        });
    };
    StockDetailComponent.prototype.edit = function (stock) {
        var _this = this;
        stock.subscribe(function (stock) {
            var link = ['/stock-exchanges', stock.id, 'edit']; // TODO: check if this is the right way to create link like that
            _this.router.navigate(link);
        });
    };
    StockDetailComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'stock-detail',
            templateUrl: 'stock-detail.component.html',
            styleUrls: ['stock-detail.component.css'],
            directives: [router_1.ROUTER_DIRECTIVES, button_1.MD_BUTTON_DIRECTIVES, icon_1.MdIcon]
        }), 
        __metadata('design:paramtypes', [stock_service_1.StockService, router_1.ActivatedRoute, router_1.Router, platform_browser_1.Title])
    ], StockDetailComponent);
    return StockDetailComponent;
}());
exports.StockDetailComponent = StockDetailComponent;
//# sourceMappingURL=stock-detail.component.js.map