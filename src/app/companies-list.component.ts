import { Component } from '@angular/core';

import { MD_CARD_DIRECTIVES } from '@angular2-material/card';

@Component({
    moduleId: module.id,
    selector: 'companies-list',
    templateUrl: 'companies-list.component.html',
    styleUrls: ['companies-list.component.css'],
    directives: [MD_CARD_DIRECTIVES]
})
export class CompaniesListComponent {
    
}