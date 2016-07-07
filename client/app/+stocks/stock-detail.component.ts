import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router, ActivatedRoute, ROUTER_DIRECTIVES } from '@angular/router';

import { MD_BUTTON_DIRECTIVES } from '@angular2-material/button';

import { FirebaseObjectObservable } from 'angularfire2';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stock-detail',
    templateUrl: 'stock-detail.component.html',
    styleUrls: ['stock-detail.component.css'],
    directives: [ROUTER_DIRECTIVES, MD_BUTTON_DIRECTIVES]

})
export class StockDetailComponent implements OnInit {
    stock: FirebaseObjectObservable<StockExchange>;
    private routeParams: any; // TODO: strongly type it

    constructor(private companiesService: StockService, private route: ActivatedRoute, private router: Router, private titleService: Title) { }

    ngOnInit() {
        this.routeParams = this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.stock = this.companiesService.getCompany(id);
                this.stock.subscribe((stock: StockExchange) => {
                    this.titleService.setTitle(stock.name)
                });
            }

        });
    }

    edit(stock: FirebaseObjectObservable<StockExchange>) {
        stock.subscribe((stock: StockExchange) => {
            let link = ['/stock-exchanges', stock.id, 'edit']; // TODO: check if this is the right way to create link like that
            this.router.navigate(link);
        })
    }
}