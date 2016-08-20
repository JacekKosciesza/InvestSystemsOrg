import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FirebaseListObservable } from 'angularfire2';

import { Term } from './term';
import { TermsService } from './terms.service';

@Component({
    moduleId: module.id,
    selector: 'terms-list',
    templateUrl: 'terms-list.component.html'
})
export class TermsListComponent implements OnInit {
    @Input() terms: FirebaseListObservable<Term[]>;

    constructor(private termsService: TermsService, private router: Router) { }

    ngOnInit() {
        if (!this.terms) {
            this.terms = this.termsService.getTerms();
        }        
    }
}