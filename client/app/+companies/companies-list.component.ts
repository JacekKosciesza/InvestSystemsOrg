import { Component } from '@angular/core';
//import { AngularFire, FirebaseListObservable } from 'angularfire2';

@Component({
    selector: 'companies-list',
    template: `
  <ul>
    <li *ngFor="let item of items | async">
      {{ item.name }}
    </li>
  </ul>
  `
})
export class MyApp {
    // items: FirebaseListObservable<any[]>;
    // constructor(af: AngularFire) {
    //     this.items = af.database.list('/items');
    // }
}