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
var angularfire2_1 = require('angularfire2');
var spinner_service_1 = require('../shared/spinner/spinner.service');
var LeadersService = (function () {
    function LeadersService(af, spinnerService) {
        this.af = af;
        this.spinnerService = spinnerService;
    }
    LeadersService.prototype.getLeaders = function () {
        var _this = this;
        this.spinnerService.show();
        // TODO: return this.af.database.list('leaders').finally(() => {this.spinnerService.hide();}); // why this does not work?
        var observable = this.af.database.list('leaders');
        observable.subscribe(function () { _this.spinnerService.hide(); });
        return observable;
    };
    LeadersService.prototype.getLeader = function (symbol) {
        return this.af.database.object("leaders/" + symbol);
    };
    LeadersService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [angularfire2_1.AngularFire, spinner_service_1.SpinnerService])
    ], LeadersService);
    return LeadersService;
}());
exports.LeadersService = LeadersService;
//# sourceMappingURL=leaders.service.js.map