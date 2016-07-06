"use strict";
// Imports for loading & configuring the in-memory web api
var http_1 = require('@angular/http');
var angularfire2_1 = require('angularfire2');
var angular2_in_memory_web_api_1 = require('angular2-in-memory-web-api');
var in_memory_circle_data_service_1 = require('./three-circles/in-memory-circle-data.service');
// The usual bootstrapping imports
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var platform_browser_1 = require('@angular/platform-browser');
var app_component_1 = require('./app.component');
var app_routes_1 = require('./app.routes');
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
    { provide: http_1.XHRBackend, useClass: angular2_in_memory_web_api_1.InMemoryBackendService },
    { provide: angular2_in_memory_web_api_1.SEED_DATA, useClass: in_memory_circle_data_service_1.InMemoryDataService },
    platform_browser_1.Title
]).then(function () { return window.console.info('Angular finished bootstrapping your application!'); }, function (error) {
    console.warn('Angular was not able to bootstrap your application.');
    console.error(error);
});
//# sourceMappingURL=main.js.map