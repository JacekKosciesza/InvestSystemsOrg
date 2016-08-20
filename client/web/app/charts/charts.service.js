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
var Subject_1 = require('rxjs/Subject');
var ChartsService = (function () {
    function ChartsService() {
        this.loadCalled = false;
        // Observable boolean sources
        this.chartsLoadedSource = new Subject_1.Subject();
        // Observable boolean streams
        this.chartsLoaded$ = this.chartsLoadedSource.asObservable();
    }
    ChartsService.prototype.load = function () {
        if (!this.loadCalled) {
            google.charts.load('current', { 'packages': ['line'] });
            google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
            this.loadCalled = true;
        }
    };
    ChartsService.prototype.onChartsLoaded = function () {
        this.chartsLoadedSource.next(true);
    };
    ChartsService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], ChartsService);
    return ChartsService;
}());
exports.ChartsService = ChartsService;
//# sourceMappingURL=charts.service.js.map