import { Component } from '@angular/core';
import { Platform, NavParams, ViewController } from 'ionic-angular';

@Component({
    selector: 'company-edit',
    templateUrl: 'company-edit.component.html'
})
export class CompanyEditComponent {
  company;

  constructor(
      public platform: Platform,
      public params: NavParams,
      public viewCtrl: ViewController
  ) {
    this.company = this.params.get('company');
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }

  save() {
  }
}