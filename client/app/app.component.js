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
var router_deprecated_1 = require('@angular/router-deprecated');
var angularfire2_1 = require('angularfire2');
var toolbar_1 = require('@angular2-material/toolbar');
var button_1 = require('@angular2-material/button');
var dashboard_component_1 = require('./+dashboard/dashboard.component');
var companies_component_1 = require('./+companies/companies.component');
var stocks_component_1 = require('./+stocks/stocks.component');
// Rule One
var rule_one_notes_component_1 = require('./notes/rule-one-notes.component');
var three_circles_component_1 = require('./three-circles/three-circles.component');
// @ngrx/store
var store_1 = require('@ngrx/store');
var area_reducer_1 = require('./three-circles/area.reducer');
var AppComponent = (function () {
    function AppComponent(af) {
        var _this = this;
        this.af = af;
        // constructor(
        //     private store : Store<any>
        // ){}
        this.title = 'InvestSystems.org';
        this.toolbarColor = 'primary';
        this.updateOnlineOfflineIndicator = function () {
            if (navigator.onLine) {
                console.log('Online');
                _this.toolbarColor = 'primary';
            }
            else {
                console.log('Offline');
                _this.toolbarColor = 'default';
            }
        };
    }
    AppComponent.prototype.ngOnInit = function () {
        window.addEventListener('online', this.updateOnlineOfflineIndicator);
        window.addEventListener('offline', this.updateOnlineOfflineIndicator);
        this.updateOnlineOfflineIndicator();
    };
    AppComponent.prototype.login = function () {
        this.af.auth.login();
    };
    AppComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'invest-systems-org',
            templateUrl: 'app.component.html',
            styleUrls: ['app.component.css'],
            directives: [router_deprecated_1.ROUTER_DIRECTIVES, toolbar_1.MdToolbar, button_1.MD_BUTTON_DIRECTIVES],
            providers: [
                router_deprecated_1.ROUTER_PROVIDERS,
                store_1.provideStore({ areas: area_reducer_1.areasReducer }),
            ]
        }),
        router_deprecated_1.RouteConfig([
            {
                path: '/',
                name: 'Dashboard',
                component: dashboard_component_1.DashboardComponent,
                useAsDefault: true
            },
            {
                path: '/companies/...',
                name: 'Companies',
                component: companies_component_1.CompaniesComponent,
            },
            {
                path: '/stock-exchanges/...',
                name: 'Stocks',
                component: stocks_component_1.StocksComponent,
            },
            {
                path: '/notes',
                name: 'Notes',
                component: rule_one_notes_component_1.RuleOneNotes,
            },
            {
                path: '/three-circles',
                name: 'ThreeCircles',
                component: three_circles_component_1.ThreeCirclesComponent
            },
        ]), 
        __metadata('design:paramtypes', [angularfire2_1.AngularFire])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map