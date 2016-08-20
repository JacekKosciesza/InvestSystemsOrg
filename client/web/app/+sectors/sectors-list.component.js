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
var sector_1 = require('./sector');
var subsector_1 = require('./subsector');
var industry_1 = require('./industry');
var sectors_service_1 = require('./sectors.service');
var SectorsListComponent = (function () {
    function SectorsListComponent(leadersService, router, titleService) {
        this.leadersService = leadersService;
        this.router = router;
        this.titleService = titleService;
    }
    SectorsListComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (!this.sectors) {
            this.leadersService.getSectors()
                .subscribe(function (sectors) {
                _this.sectors = sectors.map(function (s) {
                    var subsectors = Object.values(s.subsectors).map(function (x) {
                        var industries = Object.values(x.industries).map(function (x) { return new industry_1.Industry(x.name); });
                        return new subsector_1.Subsector(x.name, industries);
                    });
                    return new sector_1.Sector(s.name, subsectors);
                });
            });
            this.titleService.setTitle('Sectors');
        }
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
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