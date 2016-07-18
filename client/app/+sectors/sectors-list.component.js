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
var angularfire2_1 = require('angularfire2');
var sectors_service_1 = require('./sectors.service');
var SectorsListComponent = (function () {
    function SectorsListComponent(leadersService, router, titleService) {
        this.leadersService = leadersService;
        this.router = router;
        this.titleService = titleService;
    }
    SectorsListComponent.prototype.ngOnInit = function () {
        if (!this.sectors) {
            this.sectors = this.leadersService.getSectors();
            this.titleService.setTitle('Sectors');
        }
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', angularfire2_1.FirebaseListObservable)
    ], SectorsListComponent.prototype, "sectors", void 0);
    SectorsListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'sectors-list',
            templateUrl: 'sectors-list.component.html'
        }), 
        __metadata('design:paramtypes', [sectors_service_1.SectorsService, router_1.Router, platform_browser_1.Title])
    ], SectorsListComponent);
    return SectorsListComponent;
}());
exports.SectorsListComponent = SectorsListComponent;
//# sourceMappingURL=sectors-list.component.js.map