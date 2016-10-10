import { Injectable, Inject } from '@angular/core';

import { AppConfig } from './app-config';
import { APP_CONFIG_TOKEN } from './app-config.provider';

@Injectable()
export class Settings extends AppConfig {
    constructor(@Inject(APP_CONFIG_TOKEN) private config: AppConfig) {
        super();
        this.culture = config.culture;
        this.theme = config.theme;
        this.tutorial = config.tutorial;        
    }
}