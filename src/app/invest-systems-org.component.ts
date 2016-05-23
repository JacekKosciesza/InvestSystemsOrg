import { Component, OnInit } from '@angular/core';
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
export class InvestSystemsOrgAppComponent implements OnInit {
  title: String = 'Invest Systems';
  toolbarColor: String = 'primary';
  
  constructor(mdIconRegistry: MdIconRegistry) {
    mdIconRegistry
        .addSvgIcon('thumb-up', '/assets/icons/thumbup-icon.svg')
        .addSvgIconSetInNamespace('core', '/assets/icons/core-icon-set.svg')
        .registerFontClassAlias('fontawesome', 'fa');
  }
  
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
