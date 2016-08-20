import { RouterConfig } from '@angular/router';

import { AuthGuard } from '../auth.guard'

import { StocksComponent } from './stocks.component'
import { StocksListComponent } from './stocks-list.component'
import { StockCreateComponent } from './stock-create.component'
import { StockDetailComponent } from './stock-detail.component'
import { StockEditComponent } from './stock-edit.component'

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
                path: 'create',
                component: StockCreateComponent,
                canActivate: [AuthGuard]
            },
            {
                path: ':id',
                component: StockDetailComponent
            },
            {
                path: ':id/edit',
                component: StockEditComponent,
                canActivate: [AuthGuard]
            }
        ]
    }
]