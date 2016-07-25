import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { CONFIG } from '../shared/config';
import { LogService } from '../shared/log/log.service'
import { SpinnerService } from '../shared/spinner/spinner.service'
import { Company } from '../+companies/company'; // TODO: move to shared?

let portfolioUrl = CONFIG.baseUrls.portfolio;

@Injectable()
export class PortfolioService {

    constructor(private log: LogService, private af: AngularFire, private spinnerService: SpinnerService) { }

    getCompanies(user: string) {
        //this.log.init();
        this.log.info('PortfolioService.getCompanies');
        this.log.error('PortfolioService.getCompanies');
        return this.af.database.list(`${portfolioUrl}/${user}`, {
            query: {
                orderByChild: 'order',
            }
        }) as FirebaseListObservable<Company[]>
    }
}