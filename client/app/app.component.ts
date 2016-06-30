import { Component }       from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { MdToolbar } from '@angular2-material/toolbar';

import { DashboardComponent } from './+dashboard/dashboard.component'

// Rule One
import { RuleOneNotes } from './notes/rule-one-notes.component'
import { ThreeCirclesComponent } from './three-circles/three-circles.component'

// @ngrx/store
import { Store, provideStore } from '@ngrx/store';
import { areasReducer } from './three-circles/area.reducer'

@Component({
    moduleId: module.id,
    selector: 'invest-systems-org',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css'],
    directives: [ROUTER_DIRECTIVES, MdToolbar],
    providers: [
        ROUTER_PROVIDERS,
        provideStore({ areas: areasReducer }),
    ]
})
@RouteConfig([
    {
        path: '/',
        name: 'Dashboard',
        component: DashboardComponent,
        useAsDefault: true
    },
    {
        path: '/notes',
        name: 'Notes',
        component: RuleOneNotes,
    },
    {
        path: '/three-circles',
        name: 'ThreeCircles',
        component: ThreeCirclesComponent
    },
])
export class AppComponent {
    // constructor(
    //     private store : Store<any>
    // ){}

    title = 'InvestSystems.org';

    toolbarColor: String = 'primary';

    ngOnInit() {
        window.addEventListener('online', this.updateOnlineOfflineIndicator);
        window.addEventListener('offline', this.updateOnlineOfflineIndicator);
        this.updateOnlineOfflineIndicator()
    }

    updateOnlineOfflineIndicator = () => {
        if (navigator.onLine) {
            console.log('Online');
            this.toolbarColor = 'primary';
        } else {
            console.log('Offline');
            this.toolbarColor = 'default';
        }
    }
}
