import { Component, OnInit } from '@angular/core';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

@Component({
    moduleId: module.id,
    selector: 'invsys-dashboard',
    templateUrl: 'dashboard.component.html',
    styleUrls: ['dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    items: FirebaseListObservable<any[]>;

    constructor(private af: AngularFire) { }

    ngOnInit() {
        this.items = this.af.database.list('items');
    }
}