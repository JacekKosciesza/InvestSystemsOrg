import { Component, OnInit } from '@angular/core';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { WatchlistService } from './watchlist.service';

@Component({
    selector: 'user-watchlist',
    templateUrl: 'build/+dashboard/watchlist/user-watchlist.component.html',
    pipes: [TranslatePipe],
    providers: [WatchlistService]
})
export class UserWatchlistComponent implements OnInit {
    companies: any[];

    constructor(private watchlistService: WatchlistService) { }

    ngOnInit() {
        this.watchlistService.getWatchlist('6E274718-69D8-4F7A-8F08-2F868182C758').then(companies => {
            this.companies = companies;
        });
    }
}