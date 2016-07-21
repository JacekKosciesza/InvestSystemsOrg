"use strict";
// Imports for loading & configuring the in-memory web api
var http_1 = require('@angular/http');
var icon_registry_1 = require('@angular2-material/icon/icon-registry');
var auth_guard_1 = require('./auth.guard');
var forms_1 = require('@angular/forms');
var angularfire2_1 = require('angularfire2');
// The usual bootstrapping imports
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var platform_browser_1 = require('@angular/platform-browser');
var app_component_1 = require('./app.component');
var app_routes_1 = require('./app.routes');
var charts_service_1 = require('./charts/charts.service');
var spinner_service_1 = require('./shared/spinner/spinner.service');
platform_browser_dynamic_1.bootstrap(app_component_1.AppComponent, [
    app_routes_1.APP_ROUTER_PROVIDER,
    http_1.HTTP_PROVIDERS,
    angularfire2_1.FIREBASE_PROVIDERS,
    // Initialize Firebase app  
    angularfire2_1.defaultFirebase({
        apiKey: "AIzaSyBxTIFIwi_rWHM3oeAtXSEi1nrEUvvlqu8",
        authDomain: "investsystemsorg.firebaseapp.com",
        databaseURL: "https://investsystemsorg.firebaseio.com",
        storageBucket: "investsystemsorg.appspot.com",
    }),
    angularfire2_1.firebaseAuthConfig({
        provider: angularfire2_1.AuthProviders.Google,
        method: angularfire2_1.AuthMethods.Redirect
    }),
    // { provide: XHRBackend, useClass: InMemoryBackendService }, // in-mem server
    // { provide: SEED_DATA, useClass: InMemoryDataService },      // in-mem server data
    platform_browser_1.Title,
    auth_guard_1.AuthGuard,
    icon_registry_1.MdIconRegistry,
    forms_1.disableDeprecatedForms(),
    forms_1.provideForms(),
    charts_service_1.ChartsService,
    spinner_service_1.SpinnerService
]).then(function () { return window.console.info('Angular finished bootstrapping your application!'); }, function (error) {
    console.warn('Angular was not able to bootstrap your application.');
    console.error(error);
});
//# sourceMappingURL=main.js.map