import { Component } from '@angular/core';
import { MdToolbar } from '@angular2-material/toolbar';
import { MdIconRegistry, MdIcon } from '@angular2-material/icon';

@Component({
  moduleId: module.id,
  selector: 'invest-systems-org-app',
  templateUrl: 'invest-systems-org.component.html',
  styleUrls: ['invest-systems-org.component.css'],
  viewProviders: [MdIconRegistry],
  directives: [MdToolbar, MdIcon]
})
export class InvestSystemsOrgAppComponent {
  constructor(mdIconRegistry: MdIconRegistry) {
    mdIconRegistry
        .addSvgIcon('thumb-up', '/assets/icons/thumbup-icon.svg')
        .addSvgIconSetInNamespace('core', '/assets/icons/core-icon-set.svg')
        .registerFontClassAlias('fontawesome', 'fa');
  }
  title = 'Invest Systems';
}
