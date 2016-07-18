import { Component, Input, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { FirebaseListObservable } from 'angularfire2';

import { Sector } from './sector';
import { SectorsService } from './sectors.service';

@Component({
    moduleId: module.id,
    selector: 'sectors-list',
    templateUrl: 'sectors-list.component.html'
})
export class SectorsListComponent implements OnInit {
    @Input() sectors: FirebaseListObservable<Sector[]>;

    constructor(private leadersService: SectorsService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        if (!this.sectors) {
            this.sectors = this.leadersService.getSectors();
            this.titleService.setTitle('Sectors');
        }        
    }
}