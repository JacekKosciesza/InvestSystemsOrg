import { NgModule } from '@angular/core';
import { IonicApp, IonicModule } from 'ionic-angular';
import {Http} from '@angular/http';

import { MyApp } from './app.component';

import { TranslatePipe, TranslateService, TranslateLoader, TranslateStaticLoader } from 'ng2-translate/ng2-translate';

import { RuleOneRatingComponent } from '../+rule-one'

// Pages
import { DashboardComponent } from '../+dashboard';
import { CompanyListComponent, CompanyDetailComponent, CompanyEditComponent, CompanyService } from '../+companies';

// Components
import { SignInComponent, IdentityPopoverComponent, IdentityService } from '../+identity'
import { UserPortfolioComponent, UserWatchlistComponent } from '../+dashboard';
import {
  RuleOneComponent,
  MeaningStatementComponent,
  ThreeCirclesComponent,
  FiveMoatsComponent,
  BigFiveComponent,
  BigFiveAnnualComponent,
  BigFiveGrowthComponent,
  EmaChartComponent,
  MacdChartComponent,
  StochasticChartComponent,
  MoatComponent,
  MeaningComponent,
  LevelFiveLeadersComponent,
  MarginComponent,
  ThreeToolsComponent,
  //MarginData
 } from '../+rule-one'


// Services
import { PortfolioService, WatchlistService } from '../+dashboard';
import { ManagementService, MarginService, MeaningService, MoatService, ThreeToolsService } from '../+rule-one'

// import { InMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AboutPage, AboutTab, TeamTab, ContactTab } from '../pages/about'

@NgModule({
  declarations: [
    MyApp,
    // Pages
    DashboardComponent,
    CompanyListComponent,
    CompanyDetailComponent,
    CompanyEditComponent,
    AboutPage,
    // Components
    AboutTab,
    TeamTab,
    ContactTab,
    SignInComponent,
    UserPortfolioComponent,
    UserWatchlistComponent,
    RuleOneComponent,
    RuleOneRatingComponent,
    BigFiveAnnualComponent,
    BigFiveGrowthComponent,
    MeaningStatementComponent,
    ThreeCirclesComponent,
    FiveMoatsComponent,
    BigFiveComponent,
    EmaChartComponent,
    MacdChartComponent,
    StochasticChartComponent,
    MoatComponent,
    MeaningComponent,
    LevelFiveLeadersComponent,
    MarginComponent,
    ThreeToolsComponent,
    IdentityPopoverComponent,
    // Pipes
    TranslatePipe
  ],
  imports: [
    IonicModule.forRoot(MyApp),
    //InMemoryWebApiModule.forRoot(MarginData)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    AboutPage,
    SignInComponent,
    DashboardComponent,
    CompanyListComponent,
    CompanyDetailComponent,
    CompanyEditComponent,
    AboutTab,
    TeamTab,
    ContactTab
  ],
  providers: [
    // Services
    IdentityService,
    TranslateService,
    PortfolioService,
    WatchlistService,
    ManagementService,
    MeaningService,
    CompanyService,
    MoatService,
    MarginService,
    ThreeToolsService,
    {
      provide: TranslateLoader,
      useFactory: (http: Http) => new TranslateStaticLoader(http, 'assets/i18n', '.json'),
      deps: [Http]
    }
  ]
})
export class AppModule {}
