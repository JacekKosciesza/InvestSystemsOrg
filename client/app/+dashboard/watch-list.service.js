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
var WatchListService = (function () {
    function WatchListService(af, spinnerService) {
        this.af = af;
        this.spinnerService = spinnerService;
    }
    WatchListService.prototype.getCompanies = function (user) {
        return this.af.database.list("watch-list/" + user, {
            query: {
                orderByChild: 'order',
            }
        });
    };
    WatchListService = __decorate([
        // TODO: move to shared?
        core_1.Injectable(), 
        __metadata('design:paramtypes', [angularfire2_1.AngularFire, spinner_service_1.SpinnerService])
    ], WatchListService);
    return WatchListService;
}());
exports.WatchListService = WatchListService;
//# sourceMappingURL=watch-list.service.js.map