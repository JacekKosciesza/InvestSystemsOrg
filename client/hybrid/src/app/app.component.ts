import { Component, ViewChild, OnInit } from '@angular/core';
import { Platform, MenuController, Nav, ToastController } from 'ionic-angular';
import { StatusBar } from 'ionic-native';

import { TranslateService } from 'ng2-translate/ng2-translate';
import { DashboardComponent } from '../+dashboard';
import { CompanyListComponent } from '../+companies';
import { AboutPage, SettingsPage, TutorialPage } from '../pages';

import { ToastService } from '../services';
import { Settings } from '../shared';

@Component({
  templateUrl: 'app.html'
})
export class InvestSystems implements OnInit {
  @ViewChild(Nav) nav: Nav;
  rootPage = CompanyListComponent;
  pages: Array<{ title: string, component: any }>;
  theme: string;

  constructor(platform: Platform, public menu: MenuController, translate: TranslateService, private toastService: ToastService, public toastCtrl: ToastController, public settings: Settings) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
    });

    // this language will be used as a fallback when a translation isn't found in the current language
    translate.setDefaultLang('en');
    // the lang to use, if the lang isn't available, it will use the current loader to get them
    //translate.use('pl');

    translate.get(['Dashboard', 'Companies', 'Settings', 'Tutorial', 'About']).subscribe((t: string[]) => {
      // set our app's pages
      this.pages = [
        { title: t['Dashboard'], component: DashboardComponent },
        { title: t['Companies'], component: CompanyListComponent },
        { title: t['Settings'], component: SettingsPage },
        { title: t['Tutorial'], component: TutorialPage },
        { title: t['About'], component: AboutPage }
      ];
    });
  }

  ngOnInit() {
    this.toastService.toasts$.subscribe(toast => {
      let ionicToast = this.toastCtrl.create(toast);
      ionicToast.present();
    });
  }

  openPage(page) {
    // close the menu when clicking a link from the menu
    this.menu.close();
    // navigate to the new page if it is not the current page
    this.nav.setRoot(page.component);
  }
}
