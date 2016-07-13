import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

import { Broker } from './broker';
import { BrokerService } from './broker.service'

@Component({
    moduleId: module.id,
    templateUrl: 'brokers.component.html',
    styleUrls: ['brokers.component.css'],
    providers: [BrokerService],
    directives: [MD_CARD_DIRECTIVES]
})
export class BrokersComponent implements OnInit {TeamService
    brokers: FirebaseListObservable<Broker[]>;

    constructor(private teamService: BrokerService,  private titleService: Title) { }

    ngOnInit() {
        this.brokers = this.teamService.getTeam();
        this.titleService.setTitle('Brokers');
    }
}