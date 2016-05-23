import { bootstrap } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { InvestSystemsOrgAppComponent, environment } from './app/';
import { HTTP_PROVIDERS } from '@angular/http';
import { ROUTER_PROVIDERS } from '@angular/router';
import { MdIconRegistry } from '@angular2-material/icon';
import { Renderer } from '@angular/core'; // TODO: what is that?

if (environment.production) {
  enableProdMode();
}

bootstrap(InvestSystemsOrgAppComponent, [
  HTTP_PROVIDERS,
  ROUTER_PROVIDERS,
  MdIconRegistry,
  Renderer
]);

