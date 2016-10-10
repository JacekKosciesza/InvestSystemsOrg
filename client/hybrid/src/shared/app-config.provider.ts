import { OpaqueToken, Provider } from '@angular/core';

import { AppConfig } from './app-config';

export let APP_CONFIG_TOKEN = new OpaqueToken('app.config');

export const setConfig = (config: AppConfig): Provider => {
    return { provide: APP_CONFIG_TOKEN, useValue: config };
};
