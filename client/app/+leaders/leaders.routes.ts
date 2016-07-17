import { RouterConfig } from '@angular/router';

import { LeadersComponent } from './leaders.component';
import { LeadersListComponent } from './leaders-list.component';

export const LeadersRoutes: RouterConfig = [
    {
        path: 'leaders',
        component: LeadersComponent,
        children: [
            {
                path: '',
                component: LeadersListComponent
            }
        ]
    }
];