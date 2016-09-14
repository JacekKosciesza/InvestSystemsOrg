import {Component} from '@angular/core';
import {ModalController, NavController, NavParams} from 'ionic-angular';
import {TranslatePipe} from 'ng2-translate/ng2-translate';
import {CompanyEditPage} from './company-edit';

@Component({
  templateUrl: 'build/pages/company-details/company-details.html'
})
export class CompanyDetailsPage {
  selectedItem: any;

  constructor(public navCtrl: NavController, navParams: NavParams, public modalCtrl: ModalController) {
    // If we navigated to this page, we will have an item available as a nav param
    this.selectedItem = navParams.get('item');
  }

  edit(company) {
    let modal = this.modalCtrl.create(CompanyEditPage, {company:company});
    modal.present();
  }
}
