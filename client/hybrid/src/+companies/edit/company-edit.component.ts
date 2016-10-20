import { Component, OnInit } from '@angular/core';
import { Platform, NavParams, ViewController } from 'ionic-angular';

import { Website } from '../shared';

@Component({
  selector: 'company-edit',
  templateUrl: 'company-edit.component.html'
})
export class CompanyEditComponent implements OnInit {
  company;
  website;

  constructor(
    public platform: Platform,
    public params: NavParams,
    public viewCtrl: ViewController
  ) {
    this.company = this.params.get('company');
    this.website = new Website();
  }

  ngOnInit() {
    this.company.websites = [];
  }

  add(website: Website) {
    if (website && website.type && website.link) {
      this.company.websites.push(website);
    }
  }

  remove(website: Website) {
    var index = this.company.websites.findIndex(a => a === website);
    if (index > -1) {
      this.company.websites.splice(index, 1);
    }
  }

  dismiss() {
    this.viewCtrl.dismiss();
  }

  save() {
  }
}