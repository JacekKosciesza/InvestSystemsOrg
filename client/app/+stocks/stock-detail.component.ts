import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

import { FirebaseObjectObservable } from 'angularfire2';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stock-detail',
    templateUrl: 'stock-detail.component.html',
    styleUrls: ['stock-detail.component.css']
})
export class StockDetailComponent implements OnInit {
    stock: FirebaseObjectObservable<StockExchange>;

    constructor(private companiesService: StockService, private route: ActivatedRoute, private titleService: Title) { }

    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        if (id) {
            this.stock = this.companiesService.getCompany(id);
            //this.titleService.setTitle(this.stock.name);
        }
    }
}