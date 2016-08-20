import { Component, Input, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { FirebaseListObservable } from 'angularfire2';

import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

import { Leader } from './leader';
import { LeadersService } from './leaders.service';

@Component({
    moduleId: module.id,
    selector: 'leaders-list',
    templateUrl: 'leaders-list.component.html',
    directives: [MD_CARD_DIRECTIVES]
})
export class LeadersListComponent implements OnInit {
    @Input() leaders;

    constructor(private leadersService: LeadersService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        if (!this.leaders) {
            this.leaders = this.leadersService.getLeaders();
            this.titleService.setTitle('Leaders');
        }        
    }

    gotoDetail(leader: Leader) {
        let link = ['/leaders/', leader.$key];
        this.router.navigate(link);
    }
}