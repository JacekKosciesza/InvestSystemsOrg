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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require('@angular/core');
var angularfire2_1 = require('angularfire2');
var index_1 = require('../shared/config/index');
var SectorsService = (function () {
    function SectorsService(config, af) {
        this.config = config;
        this.af = af;
    }
    SectorsService.prototype.getSectors = function () {
        return this.af.database.list(this.config.baseUrls.sectors);
    };
    SectorsService.prototype.getSector = function (id) {
        return this.af.database.object(this.config.baseUrls.sectors + "/" + id);
    };
    SectorsService = __decorate([
        core_1.Injectable(),
        __param(0, core_1.Inject(index_1.APP_CONFIG)), 
        __metadata('design:paramtypes', [Object, angularfire2_1.AngularFire])
    ], SectorsService);
    return SectorsService;
}());
exports.SectorsService = SectorsService;
//# sourceMappingURL=sectors.service.js.map