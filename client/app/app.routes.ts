import { provideRouter, RouterConfig } from '@angular/router';

import { DashboardComponent } from './+dashboard/dashboard.component'
import { CompaniesRoutes } from './+companies/companies.routes'
import { StocksRoutes } from './+stocks/stocks.routes'
import { LeadersRoutes } from './+leaders/leaders.routes'
import { SectorsRoutes } from './+sectors/sectors.routes'
import { RuleOneNotes } from './notes/rule-one-notes.component'
import { ThreeCirclesComponent } from './three-circles/three-circles.component'
import { TeamComponent } from './+about/team.component'
import { ContactComponent } from './+contact/contact.component'
import { BrokersComponent } from './+brokers/brokers.component'
import { YahooFinanceComponent } from './yahoo-finance/yahoo-finance.component'

export const AppRoutes: RouterConfig = [
    {
        path: '',
        component: DashboardComponent
    },
    ...CompaniesRoutes,
    ...StocksRoutes,
    ...LeadersRoutes,
    ...SectorsRoutes,
    {
        path: 'notes',
        component: RuleOneNotes
    },
    {
        path: 'three-circles',
        component: ThreeCirclesComponent
    },
    {
        path: 'about/team',
        component: TeamComponent
    },
    {
        path: 'contact',
        component: ContactComponent
    },
    {
        path: 'brokers',
        component: BrokersComponent
    },
    {
        path: 'yahoo-finance',
        component: YahooFinanceComponent
    },
];

export const APP_ROUTER_PROVIDER = provideRouter(AppRoutes);
