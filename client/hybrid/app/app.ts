import {Component, ViewChild} from '@angular/core';
import {Http} from '@angular/http';
import {ionicBootstrap, Platform, MenuController, Nav} from 'ionic-angular';
import {StatusBar} from 'ionic-native';
import { DashboardComponent } from './+dashboard';
import { CompanyListComponent } from './+companies'
//import { SignInPage } from './pages/sign-in/sign-in'
import { TranslateService, TranslateLoader, TranslateStaticLoader } from 'ng2-translate/ng2-translate';
import { IdentityService } from './+identity'


@Component({
  templateUrl: 'build/app.html'
})
class MyApp {
  @ViewChild(Nav) nav: Nav;

  // make HelloIonicPage the root (or first) page
  rootPage: any = CompanyListComponent; // TODO: DashboardPage;
  pages: Array<{ title: string, component: any }>;

  constructor(
    public platform: Platform,
    public menu: MenuController,
    translate: TranslateService
  ) {
    this.initializeApp();

    // this language will be used as a fallback when a translation isn't found in the current language
    translate.setDefaultLang('en');
    // the lang to use, if the lang isn't available, it will use the current loader to get them
    //translate.use('pl');

    translate.get(['Dashboard', 'Companies']).subscribe((t: string[]) => {
      // set our app's pages
      this.pages = [
        { title: t['Dashboard'], component: DashboardComponent },
        { title: t['Companies'], component: CompanyListComponent }
      ];
    });
  }

  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
    });
  }

  openPage(page) {
    // close the menu when clicking a link from the menu
    this.menu.close();
    // navigate to the new page if it is not the current page
    this.nav.setRoot(page.component);
  }
}

ionicBootstrap(MyApp, [
  {
    provide: TranslateLoader,
    useFactory: (http: Http) => new TranslateStaticLoader(http, 'assets/i18n', '.json'),
    deps: [Http]
  },
  TranslateService,
  IdentityService
]);
