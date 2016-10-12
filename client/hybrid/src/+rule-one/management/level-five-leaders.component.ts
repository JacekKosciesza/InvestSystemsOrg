import { Component, OnInit, Input } from '@angular/core';

import { ManagementService } from './management.service';
import { Leader } from './leader.model';

@Component({
    selector: 'level-five-leaders',
    templateUrl: 'level-five-leaders.component.html'
})
export class LevelFiveLeadersComponent implements OnInit {
    @Input() companySymbol: string;
    public leaders: Array<Leader>;
    public more: Array<boolean>;

    constructor(public managementService: ManagementService) {
        this.more = [];
    }

    ngOnInit() {
        this.managementService.getLeaders(this.companySymbol).then(leaders => {
            this.leaders = leaders;
        });
    }
}