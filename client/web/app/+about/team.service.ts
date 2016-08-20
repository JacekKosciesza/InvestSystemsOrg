import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { TeamMember } from './team-member';


@Injectable()
export class TeamService {

    constructor(private af: AngularFire) { }

    getTeam(): FirebaseListObservable<TeamMember[]> {
        return this.af.database.list('about/team', {query:{orderByChild: 'order'}}) as FirebaseListObservable<TeamMember[]>;
    }
}