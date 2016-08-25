import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import { CompanyDetailsPage } from '../company-details/company-details';
import { SignInPage } from '../sign-in/sign-in'
import {TranslatePipe} from 'ng2-translate/ng2-translate';

@Component({
    templateUrl: 'build/pages/companies-list/companies-list.html',
    pipes: [TranslatePipe]
})
export class CompaniesListPage {
    selectedItem: any;
    companies: any;

    constructor(public navCtrl: NavController, navParams: NavParams) {
        // If we navigated to this page, we will have an item available as a nav param
        this.selectedItem = navParams.get('item');

        this.initializeCompanies();
    }

    initializeCompanies() {
        this.companies = [
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
            {
                logo: 'img/MENT.png',
                name: 'Mentor Graphics Corp',
                symbol: 'MENT'
            },
            {
                logo: 'img/EPAM.png',
                name: 'EPAM Systems Inc',
                symbol: 'EPAM'
            },
        ]
    }

    getCompanies(ev: any) {
        // Reset items back to all of the items
        this.initializeCompanies();

        // set val to the value of the searchbar
        let val = ev.target.value;

        // if the value is an empty string don't filter the items
        if (val && val.trim() != '') {
            this.companies = this.companies.filter((company) => {
                return (company.name.toLowerCase().indexOf(val.toLowerCase()) > -1);
            })
        }
    }

    doInfinite(infiniteScroll) {
        console.log('Begin async operation');

        setTimeout(() => {
            for (var i = 0; i < 30; i++) {
                this.companies.push({ name: `Company ${i}` });
            }

            console.log('Async operation has ended');
            infiniteScroll.complete();
        }, 500);
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
