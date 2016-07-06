import { RouterConfig } from '@angular/router';

import { StocksComponent } from './stocks.component'
import { StocksListComponent } from './stocks-list.component'
import { StockDetailComponent } from './stock-detail.component'

export const StocksRoutes: RouterConfig = [
    {
        path: 'stock-exchanges',
        component: StocksComponent,
        children: [
            {
                path: '',
                component: StocksListComponent
            },
            {
                path: ':id',
                component: StockDetailComponent
            }
        ]
    }
]