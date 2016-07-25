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
var sectors_service_1 = require('./sectors.service');
var SectorDetailComponent = (function () {
    function SectorDetailComponent(sectorsService, route, titleService) {
        this.sectorsService = sectorsService;
        this.route = route;
        this.titleService = titleService;
    }
    SectorDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.routeParams = this.route.params.subscribe(function (params) {
            var id = params['id'];
            _this.company = _this.sectorsService.getSector(id);
        });
    };
    SectorDetailComponent.prototype.ngOnDestroy = function () {
        this.routeParams.unsubscribe();
    };
    SectorDetailComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'sector-detail',
            templateUrl: 'sector-detail.component.html'
        }), 
        __metadata('design:paramtypes', [sectors_service_1.SectorsService, router_1.ActivatedRoute, platform_browser_1.Title])
    ], SectorDetailComponent);
    return SectorDetailComponent;
}());
exports.SectorDetailComponent = SectorDetailComponent;
//# sourceMappingURL=sector-detail.component.js.map