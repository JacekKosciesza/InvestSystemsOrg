import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { SpinnerService } from '../shared/spinner/spinner.service'
import { Leader } from './leader';


@Injectable()
export class LeadersService {

    constructor(private af: AngularFire, private spinnerService: SpinnerService) { }

    getLeaders() {
        this.spinnerService.show()
        // TODO: return this.af.database.list('leaders').finally(() => {this.spinnerService.hide();}); // why this does not work?
        let observable = this.af.database.list('leaders');
        observable.subscribe(() => {this.spinnerService.hide();});

        return observable; 
    }

    getLeader(symbol: string): FirebaseObjectObservable<Leader> {
        return this.af.database.object(`leaders/${symbol}`) as FirebaseObjectObservable<Leader>;
    }
}