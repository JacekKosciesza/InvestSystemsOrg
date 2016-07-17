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
var router_1 = require('@angular/router');
var leaders_service_1 = require('./leaders.service');
var LeadersComponent = (function () {
    function LeadersComponent() {
    }
    LeadersComponent.prototype.ngOnInit = function () {
    };
    LeadersComponent = __decorate([
        core_1.Component({
            template: "\n    <h1>Leaders</h1>\n    <router-outlet></router-outlet>\n  ",
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [leaders_service_1.LeadersService]
        }), 
        __metadata('design:paramtypes', [])
    ], LeadersComponent);
    return LeadersComponent;
}());
exports.LeadersComponent = LeadersComponent;
//# sourceMappingURL=leaders.component.js.map