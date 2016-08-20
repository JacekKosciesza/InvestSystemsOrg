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
var terms_service_1 = require('./terms.service');
var GlossaryComponent = (function () {
    function GlossaryComponent(titleService) {
        this.titleService = titleService;
    }
    GlossaryComponent.prototype.ngOnInit = function () {
        this.titleService.setTitle('Glossary');
    };
    GlossaryComponent = __decorate([
        core_1.Component({
            template: "\n    <h1>Glossary</h1>\n    <router-outlet></router-outlet>\n  ",
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [terms_service_1.TermsService]
        }), 
        __metadata('design:paramtypes', [platform_browser_1.Title])
    ], GlossaryComponent);
    return GlossaryComponent;
}());
exports.GlossaryComponent = GlossaryComponent;
//# sourceMappingURL=glossary.component.js.map