import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { TermsService } from './terms.service';


@Component({
    template: `
    <h1>Glossary</h1>
    <router-outlet></router-outlet>
  `,
    directives: [ROUTER_DIRECTIVES],
    providers: [TermsService]
})
export class GlossaryComponent implements OnInit {
    constructor(private titleService: Title) { }

    ngOnInit() {
        this.titleService.setTitle('Glossary');
    }
}