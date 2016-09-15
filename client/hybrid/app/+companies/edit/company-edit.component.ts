import { Component } from '@angular/core';
import { ModalController, Platform, NavParams, ViewController } from 'ionic-angular';
import { TranslatePipe } from 'ng2-translate/ng2-translate';

@Component({
    templateUrl: 'build/+companies/edit/company-edit.component.html',
    pipes: [TranslatePipe],
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
}