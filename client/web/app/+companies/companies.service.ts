import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { Company } from './company';


@Injectable()
export class CompaniesService {

    constructor(private af: AngularFire) { }

    getCompanies(): FirebaseListObservable<Company[]> {
        return this.af.database.list('companies') as FirebaseListObservable<Company[]>;
    }

    getCompany(symbol: string): FirebaseObjectObservable<Company> {
        return this.af.database.object(`companies/${symbol}`) as FirebaseObjectObservable<Company>;
    }
}