// Imports for loading & configuring the in-memory web api
import { XHRBackend, HTTP_PROVIDERS } from '@angular/http';


import { FIREBASE_PROVIDERS, defaultFirebase, firebaseAuthConfig, AuthProviders, AuthMethods } from 'angularfire2';

import { InMemoryBackendService, SEED_DATA } from 'angular2-in-memory-web-api';
import { InMemoryDataService } from './three-circles/in-memory-circle-data.service';

// The usual bootstrapping imports
import { bootstrap }      from '@angular/platform-browser-dynamic';
import { Title } from '@angular/platform-browser';

import { AppComponent }   from './app.component';
import { APP_ROUTER_PROVIDER } from './app.routes';

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
    { provide: XHRBackend, useClass: InMemoryBackendService }, // in-mem server
    { provide: SEED_DATA, useClass: InMemoryDataService },      // in-mem server data
    Title
]).then(
    () => window.console.info('Angular finished bootstrapping your application!'),
    (error) => {
        console.warn('Angular was not able to bootstrap your application.');
        console.error(error);
    }
    );
