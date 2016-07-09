import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

import { TeamMember } from './team-member';
import { TeamService } from './team.service'

@Component({
    moduleId: module.id,
    selector: 'about-team',
    templateUrl: 'team.component.html',
    styleUrls: ['team.component.css'],
    providers: [TeamService],
    directives: [MD_CARD_DIRECTIVES]
})
export class TeamComponent implements OnInit {TeamService
    team: FirebaseListObservable<TeamMember[]>;

    constructor(private teamService: TeamService,  private titleService: Title) { }

    ngOnInit() {
        this.team = this.teamService.getTeam();
        this.titleService.setTitle('About Team');
    }
}