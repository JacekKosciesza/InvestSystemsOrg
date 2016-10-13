import { Component, OnInit } from '@angular/core';
import { ModalController, NavController, NavParams } from 'ionic-angular';

import { CompanyEditComponent } from '../edit';
import { IdentityService } from '../../+identity';
import { CompanyService } from '../shared';
import { ToastService, Toast } from '../../services'

@Component({
  selector: 'company-detail',
  templateUrl: 'company-detail.component.html'
})
export class CompanyDetailComponent implements OnInit {
  company: any;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    public modalCtrl: ModalController,
    public identityService: IdentityService,
    private companyService: CompanyService,
    private toastService: ToastService) {
    // If we navigated to this page, we will have an item available as a nav param
    this.company = navParams.get('item');
    this.company.inWatchlist = false;
    this.company.inPortfolio = false;
  }

  ngOnInit() {
    var symbol = this.company.symbol;
    this.companyService.getCompany(symbol).then(company => {
      this.company = company;
    });
  }

  edit(company) {
    let modal = this.modalCtrl.create(CompanyEditComponent, { company: company });
    modal.present();
  }

  watchlist(company) {
    if (company.inWatchlist) {
      this.toastService.show(new Toast(`${company.symbol} - unwatch`, 3000)); // TOOD: better message + translation
      this.company.inWatchlist = false;
    } else {
      this.toastService.show(new Toast(`${company.symbol} - watch`, 3000)); // TOOD: better message + translation
      this.company.inWatchlist = true;
    }
  }

  portfolio(company) {
    this.company.inPortfolio = !this.company.inPortfolio;
  }
}
