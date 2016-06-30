// Imports for loading & configuring the in-memory web api
import { XHRBackend, HTTP_PROVIDERS } from '@angular/http';

import { InMemoryBackendService, SEED_DATA } from 'angular2-in-memory-web-api';
import { InMemoryDataService } from './three-circles/in-memory-circle-data.service';

// The usual bootstrapping imports
import { bootstrap }      from '@angular/platform-browser-dynamic';
import { Title } from '@angular/platform-browser';

import { AppComponent }   from './app.component';


bootstrap(AppComponent, [
    HTTP_PROVIDERS,
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
