import { Component, OnInit } from '@angular/core';
import { NavController } from 'ionic-angular';

import { SignInComponent } from '../../+identity';
import { AboutTab, TeamTab, ContactTab } from './tabs';

@Component({
    selector: 'about-page',
    templateUrl: 'about.page.html'
})
export class AboutPage implements OnInit {
    public aboutTab: any;
    public teamTab: any;
    public contactTab: any;

    constructor(public navCtrl: NavController) {
        this.aboutTab = AboutTab;
        this.teamTab = TeamTab;
        this.contactTab = ContactTab;
    }

    ngOnInit() { }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}