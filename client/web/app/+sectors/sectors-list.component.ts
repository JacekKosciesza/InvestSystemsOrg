import { Component, Input, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';

import { FirebaseListObservable } from 'angularfire2';

import { Sector } from './sector';
import { Subsector } from './subsector';
import { Industry } from './industry';
import { SectorsService } from './sectors.service';

@Component({
    moduleId: module.id,
    selector: 'sectors-list',
    templateUrl: 'sectors-list.component.html'
})
export class SectorsListComponent implements OnInit {
    @Input() sectors: Sector[];

    constructor(private leadersService: SectorsService, private router: Router, private titleService: Title) { }

    ngOnInit() {
        if (!this.sectors) {
            this.leadersService.getSectors()
                .subscribe(sectors => {
                    this.sectors = sectors.map(s => {
                        let subsectors = Object.values(s.subsectors).map(x => {
                            let industries = Object.values(x.industries).map(x => new Industry(x.name));
                            return new Subsector(x.name, industries);
                        });
                        return new Sector(s.name, subsectors)
                    });
                });
            this.titleService.setTitle('Sectors');
        }
    }
}