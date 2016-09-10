import {Component, OnInit, ViewChild} from '@angular/core';
import {NavController, NavParams, InfiniteScroll} from 'ionic-angular';
import { CompanyDetailsPage } from '../company-details/company-details';
import { SignInPage } from '../sign-in/sign-in'
import {TranslatePipe} from 'ng2-translate/ng2-translate';
import { CompaniesService } from '../../services/companies.service'

@Component({
    templateUrl: 'build/pages/companies-list/companies-list.html',
    pipes: [TranslatePipe],
    providers: [CompaniesService]
})
export class CompaniesListPage implements OnInit {
    selectedItem: any;
    companies: any[];
    page: number;
    q: string;
    @ViewChild(InfiniteScroll) private infiniteScrollControl: InfiniteScroll;

    constructor(public navCtrl: NavController, navParams: NavParams, private companiesServcie: CompaniesService) {
        // If we navigated to this page, we will have an item available as a nav param
        this.selectedItem = navParams.get('item');
        this.page = 1;
        //this.initializeCompanies();
    }

    ngOnInit() {
        console.log('ngOnInit');
        this.companiesServcie.getCompanies(this.page).then(page => {
            this.companies = page.items;
        });
    }

    getCompanies(ev: any) {
        this.infiniteScrollControl.enable(true);
        this.companies = [];
        let val = ev.target.value || '';
        this.page = 1;
        this.q = val.trim();
        this.companiesServcie.getCompanies(this.page, this.q).then(page => {
            this.companies = page.items;
        });
    }

    doInfinite(infiniteScroll) {
        console.log('Begin async operation');
        this.page++;
        this.companiesServcie.getCompanies(this.page, this.q).then(page => {
            this.companies = this.companies.concat(page.items);
            infiniteScroll.complete();
            if (!page.items.length) {
                infiniteScroll.enable(false);
            }
        });
    }

    itemTapped(event, item) {
        this.navCtrl.push(CompanyDetailsPage, {
            item: item
        });
    }

    signIn() {
        this.navCtrl.push(SignInPage);
    }
}
