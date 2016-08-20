import { Inject, Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { APP_CONFIG, AppConfig } from '../shared/config/index';
import { Sector } from './sector';

@Injectable()
export class SectorsService {

    constructor(@Inject(APP_CONFIG) private config: AppConfig,private af: AngularFire) { }

    getSectors(): FirebaseListObservable<Sector[]> {
        return this.af.database.list(this.config.baseUrls.sectors) as FirebaseListObservable<Sector[]>;
    }

    getSector(id: string): FirebaseObjectObservable<Sector> {
        return this.af.database.object(`${this.config.baseUrls.sectors}/${id}`) as FirebaseObjectObservable<Sector>;
    }
}