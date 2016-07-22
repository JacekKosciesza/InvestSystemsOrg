import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { SpinnerService } from '../shared/spinner/spinner.service'
import { Company } from '../+companies/company'; // TODO: move to shared?

@Injectable()
export class PortfolioService {

    constructor(private af: AngularFire, private spinnerService: SpinnerService) { }

    getCompanies(user: string) {
        return this.af.database.list(`portfolio/${user}`, {
            query: {
                orderByChild: 'order',
            }
        }) as FirebaseListObservable<Company[]>
    }
}