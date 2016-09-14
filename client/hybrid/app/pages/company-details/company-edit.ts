import {Component} from '@angular/core';
import {ModalController, Platform, NavParams, ViewController} from 'ionic-angular';

@Component({
    templateUrl: 'build/pages/company-details/company-edit.html'
})
export class CompanyEditPage {
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
}