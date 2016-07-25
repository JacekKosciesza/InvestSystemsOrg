import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { CONFIG } from '../shared/config';
import { Sector } from './sector';

let sectorsUrl = CONFIG.baseUrls.sectors;

@Injectable()
export class SectorsService {

    constructor(private af: AngularFire) { }

    getSectors(): FirebaseListObservable<Sector[]> {
        return this.af.database.list(sectorsUrl) as FirebaseListObservable<Sector[]>;
    }

    getSector(id: string): FirebaseObjectObservable<Sector> {
        return this.af.database.object(`${sectorsUrl}/${id}`) as FirebaseObjectObservable<Sector>;
    }
}