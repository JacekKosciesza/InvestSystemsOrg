import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { Leader } from './leader';


@Injectable()
export class LeadersService {

    constructor(private af: AngularFire) { }

    getCompanies(): FirebaseListObservable<Leader[]> {
        return this.af.database.list('leaders') as FirebaseListObservable<Leader[]>;
    }

    getCompany(symbol: string): FirebaseObjectObservable<Leader> {
        return this.af.database.object(`leaders/${symbol}`) as FirebaseObjectObservable<Leader>;
    }
}