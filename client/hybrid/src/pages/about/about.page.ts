import { Component, OnInit } from '@angular/core';
import { NavController } from 'ionic-angular';

import { SignInComponent } from '../../+identity';
import { AboutTab } from './about.tab';
import { TeamTab } from './team.tab';

@Component({
    selector: 'about-page',
    templateUrl: 'about.page.html'
})
export class AboutPage implements OnInit {
    public aboutTab: any;
    public teamTab: any;

    constructor(public navCtrl: NavController) {
        this.aboutTab = AboutTab;
        this.teamTab = TeamTab;
    }

    ngOnInit() { }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}