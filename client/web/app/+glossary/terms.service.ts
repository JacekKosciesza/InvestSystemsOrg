import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { Term } from './term';


@Injectable()
export class TermsService {

    constructor(private af: AngularFire) { }

    getTerms(): FirebaseListObservable<Term[]> {
        return this.af.database.list('glossary') as FirebaseListObservable<Term[]>;
    }
}