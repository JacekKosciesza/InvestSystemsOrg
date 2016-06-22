import { Component, OnInit } from '@angular/core';

import { MeaningCircleComponent } from './meaning-circle.component';
import { CircleDataService } from './circle-data.service'

@Component({
    moduleId: module.id,
    selector: 'three-circles',
    templateUrl: 'three-circles.component.html',
    styleUrls: ['three-circles.component.css'],
    directives: [MeaningCircleComponent],
    providers: [CircleDataService]
})
export class ThreeCirclesComponent implements OnInit {
    constructor() { }

    ngOnInit() { }

}