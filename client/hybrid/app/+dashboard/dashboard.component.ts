import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { SignInComponent } from '../+identity';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { UserPortfolioComponent } from './portfolio'
import { UserWatchlistComponent } from './watchlist'

@Component({
    templateUrl: 'build/+dashboard/dashboard.component.html',
    pipes: [TranslatePipe],
    directives: [UserPortfolioComponent, UserWatchlistComponent]
})
export class DashboardComponent {
    constructor(public navCtrl: NavController) {
    }

    signIn() {
        this.navCtrl.push(SignInComponent);
    }
}
