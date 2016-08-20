import { Inject, Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { APP_CONFIG, AppConfig } from '../shared/config/index';
import { SpinnerService } from '../shared/spinner/spinner.service'
import { Company } from '../+companies/company'; // TODO: move to shared?

@Injectable()
export class WatchListService {

    constructor(@Inject(APP_CONFIG) private config: AppConfig, private af: AngularFire, private spinnerService: SpinnerService) { }

    getCompanies(user: string) {
        return this.af.database.list(`${this.config.baseUrls.watchList}/${user}`, {
            query: {
                orderByChild: 'order',
            }
        }) as FirebaseListObservable<Company[]>
    }
}