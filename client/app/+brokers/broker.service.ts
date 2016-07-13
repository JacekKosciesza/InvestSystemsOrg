import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { Broker } from './broker';


@Injectable()
export class BrokerService {

    constructor(private af: AngularFire) { }

    getTeam(): FirebaseListObservable<Broker[]> {
        return this.af.database.list('brokers') as FirebaseListObservable<Broker[]>;
    }
}