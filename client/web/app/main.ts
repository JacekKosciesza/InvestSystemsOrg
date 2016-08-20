// Imports for loading & configuring the in-memory web api
import { XHRBackend, HTTP_PROVIDERS } from '@angular/http';
import {MdIconRegistry} from '@angular2-material/icon/icon-registry';
import { AuthGuard } from './auth.guard'


import { disableDeprecatedForms, provideForms } from '@angular/forms';

import { FIREBASE_PROVIDERS, defaultFirebase, firebaseAuthConfig, AuthProviders, AuthMethods } from 'angularfire2';

import { InMemoryBackendService, SEED_DATA } from 'angular2-in-memory-web-api';
import { InMemoryDataService } from './three-circles/in-memory-circle-data.service';

// The usual bootstrapping imports
import { bootstrap }      from '@angular/platform-browser-dynamic';
import { Title } from '@angular/platform-browser';

import { AppComponent }   from './app.component';
import { APP_ROUTER_PROVIDER } from './app.routes';

import { ChartsService } from './charts/charts.service'

import { SpinnerService } from './shared/spinner/spinner.service'

import { LogService } from './shared/log/log.service'
import { appConfig, DEFAULT_APP_CONFIG } from './shared/config/index' // TODO: check why barrel does not work?

bootstrap(AppComponent, [
    APP_ROUTER_PROVIDER,
    HTTP_PROVIDERS,
    FIREBASE_PROVIDERS,
    // Initialize Firebase app  
    defaultFirebase({
        apiKey: "AIzaSyBxTIFIwi_rWHM3oeAtXSEi1nrEUvvlqu8",
        authDomain: "investsystemsorg.firebaseapp.com",
        databaseURL: "https://investsystemsorg.firebaseio.com",
        storageBucket: "investsystemsorg.appspot.com",
    }),
    firebaseAuthConfig({
        provider: AuthProviders.Google,
        method: AuthMethods.Redirect
    }),
    // { provide: XHRBackend, useClass: InMemoryBackendService }, // in-mem server
    // { provide: SEED_DATA, useClass: InMemoryDataService },      // in-mem server data
    Title,
    AuthGuard,
    MdIconRegistry,
    disableDeprecatedForms(),
    provideForms(),
    ChartsService,
    SpinnerService,
    LogService,
    appConfig(DEFAULT_APP_CONFIG)
]).then(
    () => window.console.info('Angular finished bootstrapping your application!'),
    (error) => {
        console.warn('Angular was not able to bootstrap your application.');
        console.error(error);
    }
    );
