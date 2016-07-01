import { Component, OnInit } from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { StockService } from './stock.service'
import { StocksListComponent } from './stocks-list.component'
import { StockDetailComponent } from './stock-detail.component'

@Component({
  moduleId: module.id,
  selector: 'stock-exchanges',
  templateUrl: 'stocks.component.html',
  styleUrls: ['stocks.component.css'],
  directives: [ROUTER_DIRECTIVES],
  providers: [StockService]
})
@RouteConfig([
    {
        path: '/',
        name: 'StocksList',
        component: StocksListComponent,
        useAsDefault: true
    },
    {
        path: '/:id',
        name: 'StockDetail',
        component: StockDetailComponent,
    },
])
export class StocksComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}