import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { CONFIG } from '../shared/config';
import { SpinnerService } from '../shared/spinner/spinner.service'
import { Company } from '../+companies/company'; // TODO: move to shared?

let watchListUrl = CONFIG.baseUrls.watchList;

@Injectable()
export class WatchListService {

    constructor(private af: AngularFire, private spinnerService: SpinnerService) { }

    getCompanies(user: string) {
        return this.af.database.list(`${watchListUrl}/${user}`, {
            query: {
                orderByChild: 'order',
            }
        }) as FirebaseListObservable<Company[]>
    }
}