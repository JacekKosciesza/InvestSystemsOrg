import { Component, OnInit } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { Company } from '../+companies/company'; // TODO: move to shared?

@Component({
    moduleId: module.id,
    selector: 'invsys-dashboard',
    templateUrl: 'dashboard.component.html',
    styleUrls: ['dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    companies: FirebaseListObservable<any[]>;

    constructor(private af: AngularFire) { }

    ngOnInit() {
        this.companies = this.af.database.list('companies', { query: { orderByChild: 'order' } }) as FirebaseListObservable<Company[]>
    }
}