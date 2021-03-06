import { Injectable } from '@angular/core';

import { AngularFire, FirebaseListObservable, FirebaseObjectObservable } from 'angularfire2';

import { StockExchange } from './stock-exchange';

@Injectable()
export class StockService {
    constructor(private af: AngularFire) { }

    getStockExchanges(): FirebaseListObservable<StockExchange[]> {
        return this.af.database.list('stock-exchanges') as FirebaseListObservable<StockExchange[]>;
    }

    getStockExchange(symbol: string): FirebaseObjectObservable<StockExchange> {
        return this.af.database.object(`stock-exchanges/${symbol}`) as FirebaseObjectObservable<StockExchange>;
    }

    updategetStockExchange(stockFirebaesObject: FirebaseObjectObservable<StockExchange>, update: any) {
        stockFirebaesObject.update(update);
    }
}