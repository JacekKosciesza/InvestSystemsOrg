import { Inject, Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { APP_CONFIG, AppConfig } from '../shared/config/index';
import { LogService } from '../shared/log/log.service'
import { SpinnerService } from '../shared/spinner/spinner.service'
import { Company } from '../+companies/company'; // TODO: move to shared?


@Injectable()
export class PortfolioService {

    constructor(@Inject(APP_CONFIG) private config: AppConfig, private log: LogService, private af: AngularFire, private spinnerService: SpinnerService) { }

    getCompanies(user: string) {
        this.log.info('PortfolioService.getCompanies');
        this.log.error('PortfolioService.getCompanies');
        return this.af.database.list(`${this.config.baseUrls.portfolio}/${user}`, {
            query: {
                orderByChild: 'order',
            }
        }) as FirebaseListObservable<Company[]>
    }
}