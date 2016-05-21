import { Component } from '@angular/core';
import { MdToolbar } from '@angular2-material/toolbar';

@Component({
  moduleId: module.id,
  selector: 'invest-systems-org-app',
  templateUrl: 'invest-systems-org.component.html',
  styleUrls: ['invest-systems-org.component.css'],
  directives: [MdToolbar]
})
export class InvestSystemsOrgAppComponent {
  title = 'Invest Systems';
}
