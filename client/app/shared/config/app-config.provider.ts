import { OpaqueToken, provide, Provider } from '@angular/core';

import { AppConfig } from './app-config'

export let APP_CONFIG = new OpaqueToken('app.config');

export const appConfig = (config: AppConfig): Provider => {
    return provide(APP_CONFIG, { useValue: config });
};