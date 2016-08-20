import { RouterConfig } from '@angular/router';

import { SectorsComponent } from './sectors.component';
import { SectorsListComponent } from './sectors-list.component';

export const SectorsRoutes: RouterConfig = [
    {
        path: 'sectors',
        component: SectorsComponent,
        children: [
            {
                path: '',
                component: SectorsListComponent
            }
        ]
    }
];