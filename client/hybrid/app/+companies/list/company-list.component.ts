import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ModalController, NavController, NavParams, InfiniteScroll, LoadingController, Loading, PopoverController } from 'ionic-angular';
import { CompanyDetailComponent } from '../detail';
import { SignInComponent } from '../../+identity';
import { TranslatePipe, TranslateService } from 'ng2-translate/ng2-translate';
import { CompanyService } from '../shared';
import { CompanyEditComponent } from '../edit';
import { IdentityService, IdentityPopoverComponent } from '../../+identity';
import { RuleOneRatingComponent } from '../../+rule-one'


@Component({
    templateUrl: 'build/+companies/list/company-list.component.html',
    pipes: [TranslatePipe],
    providers: [CompanyService],
    directives: [RuleOneRatingComponent],
    styles: [`
        rule-one-rating: {
            float:rigth;
        }
    `]
})
export class CompanyListComponent implements OnInit {
    selectedItem: any;
    companies: any[];
    page: number;
    q: string;
    @ViewChild(InfiniteScroll) private infiniteScrollControl: InfiniteScroll;
    @ViewChild('popoverContent', {read: ElementRef}) content: ElementRef;
    @ViewChild('popoverText', {read: ElementRef}) text: ElementRef;
    loader: Loading;

    constructor(
        public navCtrl: NavController,
        navParams: NavParams,
        private companyService: CompanyService,
        public loadingCtrl: LoadingController,
        translate: TranslateService,
        public modalCtrl: ModalController,
        public identityService: IdentityService,
        private popoverCtrl: PopoverController) {
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
        this.companyService.getCompanies(this.page).then(page => {
            //(<any[]>page.items).forEach(item => item.isWonderful = Math.random() >= 0.5);
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
        //this.presentLoading();
        this.companyService.getCompanies(this.page, this.q).then(page => {
            this.companies = page.items;
            //this.dismissLoading();
        });
    }

    doInfinite(infiniteScroll) {
        console.log('Begin async operation');
        this.page++;
        //this.presentLoading();
        this.companyService.getCompanies(this.page, this.q).then(page => {
            this.companies = this.companies.concat(page.items);
            //this.dismissLoading();            
            infiniteScroll.complete();
            if (!page.items.length) {
                infiniteScroll.enable(false);
            }
        });
    }

    itemTapped(event, item) {
        this.navCtrl.push(CompanyDetailComponent, {
            item: item
        });
    }

    signIn() {
        //this.navCtrl.push(SignInComponent);
        let modal = this.modalCtrl.create(SignInComponent);
        modal.present();
    }

    presentLoading() {
        this.loader.present();
    }

    dismissLoading() {
        this.loader.dismiss();
    }

    create() {
        let modal = this.modalCtrl.create(CompanyEditComponent, { company: {} });
        modal.present();
    }

    presentPopover(ev) {
        let popover = this.popoverCtrl.create(IdentityPopoverComponent
        // , {
        //     contentEle: this.content.nativeElement,
        //     textEle: this.text.nativeElement
        // }
        );

        popover.present({
            ev: ev
        });
    }
}
