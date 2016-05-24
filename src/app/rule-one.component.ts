import { Component } from '@angular/core';
import { MdIconRegistry, MdIcon } from '@angular2-material/icon';


@Component({
    moduleId: module.id,
    selector: 'rule-one',
    templateUrl: 'rule-one.component.html',
    styleUrls: ['rule-one.component.css'],
    viewProviders: [MdIconRegistry],
    directives: [MdIcon]
})
export class RuleOneComponent {
    constructor(mdIconRegistry: MdIconRegistry) {
        mdIconRegistry
            .addSvgIcon('thumb-up', '/assets/icons/thumbup-icon.svg')
            .addSvgIconSetInNamespace('core', '/assets/icons/core-icon-set.svg')
            .registerFontClassAlias('fontawesome', 'fa');
    }
}