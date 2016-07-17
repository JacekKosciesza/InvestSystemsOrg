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
var card_1 = require('@angular2-material/card');
var leaders_service_1 = require('./leaders.service');
var LeadersListComponent = (function () {
    function LeadersListComponent(leadersService, router, titleService) {
        this.leadersService = leadersService;
        this.router = router;
        this.titleService = titleService;
    }
    LeadersListComponent.prototype.ngOnInit = function () {
        if (!this.leaders) {
            this.leaders = this.leadersService.getCompanies();
            this.titleService.setTitle('Leaders');
        }
    };
    LeadersListComponent.prototype.gotoDetail = function (leader) {
        var link = ['/leaders/', leader.$key];
        this.router.navigate(link);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', angularfire2_1.FirebaseListObservable)
    ], LeadersListComponent.prototype, "leaders", void 0);
    LeadersListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'leaders-list',
            templateUrl: 'leaders-list.component.html',
            directives: [card_1.MD_CARD_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [leaders_service_1.LeadersService, router_1.Router, platform_browser_1.Title])
    ], LeadersListComponent);
    return LeadersListComponent;
}());
exports.LeadersListComponent = LeadersListComponent;
//# sourceMappingURL=leaders-list.component.js.map