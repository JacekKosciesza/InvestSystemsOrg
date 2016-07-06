import { provideRouter, RouterConfig } from '@angular/router';

import { DashboardComponent } from './+dashboard/dashboard.component'
import { CompaniesRoutes } from './+companies/companies.routes'
import { StocksRoutes } from './+stocks/stocks.routes'
import { RuleOneNotes } from './notes/rule-one-notes.component'
import { ThreeCirclesComponent } from './three-circles/three-circles.component'

export const AppRoutes: RouterConfig = [
    {
        path: '',
        component: DashboardComponent
    },
    ...CompaniesRoutes,
    ...StocksRoutes,
    {
        path: 'notes',
        component: RuleOneNotes
    },
    {
        path: 'three-circles',
        component: ThreeCirclesComponent
    }
];

export const APP_ROUTER_PROVIDER = provideRouter(AppRoutes);