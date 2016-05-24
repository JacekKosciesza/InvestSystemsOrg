import { Component, OnInit } from '@angular/core';
import { MdToolbar } from '@angular2-material/toolbar';
import { MD_SIDENAV_DIRECTIVES } from '@angular2-material/sidenav';
import { RuleOneComponent } from './rule-one.component'

@Component({
  moduleId: module.id,
  selector: 'invest-systems-org-app',
  templateUrl: 'invest-systems-org.component.html',
  styleUrls: ['invest-systems-org.component.css'],
  directives: [MD_SIDENAV_DIRECTIVES, MdToolbar, RuleOneComponent]
})
export class InvestSystemsOrgAppComponent implements OnInit {
  title: String = 'Invest Systems';
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
