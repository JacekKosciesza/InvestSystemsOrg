import {Component, OnInit, ViewChild} from '@angular/core';
import {ModalController, NavController, NavParams, InfiniteScroll, LoadingController, Loading} from 'ionic-angular';
import { CompanyDetailsPage } from '../company-details/company-details';
import { SignInPage } from '../sign-in/sign-in'
import {TranslatePipe, TranslateService} from 'ng2-translate/ng2-translate';
import { CompaniesService } from '../../services/companies.service';
import {CompanyEditPage} from '../company-details/company-edit';


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
    loader: Loading;

    constructor(public navCtrl: NavController, navParams: NavParams, private companiesServcie: CompaniesService, public loadingCtrl: LoadingController, translate: TranslateService, public modalCtrl: ModalController) {
        // If we navigated to this page, we will have an item available as a nav param
        this.selectedItem = navParams.get('item');
        this.page = 1;
        //this.initializeCompanies();
        translate.get('Please wait...').subscribe((t: string) => {
            this.loader = this.loadingCtrl.create({
                content: t,
                duration: 3000
            });
        });
    }

    ngOnInit() {
        console.log('ngOnInit');
        this.presentLoading();
        this.companiesServcie.getCompanies(this.page).then(page => {
            (<any[]>page.items).forEach(item => item.isWonderful = Math.random() >= 0.5);
            this.companies = page.items;
            this.dismissLoading();
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

    presentLoading() {
        this.loader.present();
    }

    dismissLoading() {
        this.loader.dismiss();
    }

    create() {
        let modal = this.modalCtrl.create(CompanyEditPage, { company: {} });
        modal.present();
    }
}
