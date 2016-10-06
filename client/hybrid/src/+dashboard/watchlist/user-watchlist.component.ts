import { Component, OnInit } from '@angular/core';
import { WatchlistService } from './watchlist.service';

@Component({
    selector: 'user-watchlist',
    templateUrl: 'user-watchlist.component.html'
})
export class UserWatchlistComponent implements OnInit {
    public companies: any[];

    constructor(private watchlistService: WatchlistService) { }

    ngOnInit() {
        this.watchlistService.getWatchlist('6E274718-69D8-4F7A-8F08-2F868182C758').then(companies => {
            this.companies = companies;
        });
    }
}