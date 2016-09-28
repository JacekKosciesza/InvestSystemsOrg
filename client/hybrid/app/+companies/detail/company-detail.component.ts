import { Component, OnInit } from '@angular/core';
import { ModalController, NavController, NavParams } from 'ionic-angular';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { CompanyEditComponent } from '../edit';
import { IdentityService } from '../../+identity';
import { CompanyService } from '../shared';
import { RuleOneComponent } from '../../+rule-one';

@Component({
  templateUrl: 'build/+companies/detail/company-detail.component.html',
  pipes: [TranslatePipe],
  directives: [RuleOneComponent]
})
export class CompanyDetailComponent implements OnInit {
  company: any;

  constructor(
    public navCtrl: NavController,
    navParams: NavParams,
    public modalCtrl: ModalController,
    public identityService: IdentityService,
    private companyService: CompanyService) {
    // If we navigated to this page, we will have an item available as a nav param
    this.company = navParams.get('item');
  }

  ngOnInit() {
    console.log('ngOnInit');
    var symbol = this.company.symbol;
    this.companyService.getCompany(symbol).then(company => {
      this.company = company;
    });
  }

  edit(company) {
    let modal = this.modalCtrl.create(CompanyEditComponent, { company: company });
    modal.present();
  }
}
