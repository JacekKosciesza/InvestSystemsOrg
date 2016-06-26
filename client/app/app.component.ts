import { Component }       from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { HeroService }     from './hero.service';
import { DashboardComponent } from './dashboard.component'
import { HeroesComponent } from './heroes.component';
import { HeroDetailComponent } from './hero-detail.component';

// Rule One
import { RuleOneNotes } from './notes/rule-one-notes.component'
import { ThreeCirclesComponent } from './three-circles/three-circles.component'

// @ngrx/store
import { Store, provideStore } from '@ngrx/store';
import { areasReducer } from './three-circles/area.reducer'

@Component({
    selector: 'invest-systems-org',
    template: `
    <h1>{{title}}</h1>
    <nav>
        <a [routerLink]="['Notes']">Notes</a>
        <a [routerLink]="['ThreeCircles']">Three Circles</a>
    </nav>
    <router-outlet></router-outlet>
  `,
    styleUrls: ['app/app.component.css'],
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS,
        HeroService,
        provideStore({areas: areasReducer})
    ]
})
@RouteConfig([
    {
        path: '/notes',
        name: 'Notes',
        component: RuleOneNotes,
        useAsDefault: true
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
}
