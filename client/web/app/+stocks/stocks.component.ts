import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { StockService } from './stock.service'

@Component({
  moduleId: module.id,
  selector: 'stock-exchanges',
  templateUrl: 'stocks.component.html',
  styleUrls: ['stocks.component.css'],
  directives: [ROUTER_DIRECTIVES],
  providers: [StockService]
})
export class StocksComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
}