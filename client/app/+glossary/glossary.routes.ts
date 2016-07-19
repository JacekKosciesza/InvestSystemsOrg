import { RouterConfig } from '@angular/router';

import { GlossaryComponent } from './glossary.component';
import { TermsListComponent } from './terms-list.component';

export const GlossaryRoutes: RouterConfig = [
    {
        path: 'glossary',
        component: GlossaryComponent,
        children: [
            {
                path: '',
                component: TermsListComponent
            }
        ]
    }
];