import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { Sector } from './sector';


@Injectable()
export class SectorsService {

    constructor(private af: AngularFire) { }

    getSectors(): FirebaseListObservable<Sector[]> {
        return this.af.database.list('sectors2') as FirebaseListObservable<Sector[]>;
    }
}