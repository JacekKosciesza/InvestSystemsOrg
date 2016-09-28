import { Component, OnInit, Input } from '@angular/core';
import { TranslatePipe } from 'ng2-translate/ng2-translate';

import { FiveMoatsComponent } from './moat';
import { ThreeToolsComponent } from './three-tools';

@Component({
    selector: 'rule-one',
    templateUrl: 'build/+rule-one/rule-one.component.html',
    pipes: [TranslatePipe],
    directives: [FiveMoatsComponent, ThreeToolsComponent]
})
export class RuleOneComponent implements OnInit {
    @Input() companySymbol: string;

    constructor() { }

    ngOnInit() { }
}