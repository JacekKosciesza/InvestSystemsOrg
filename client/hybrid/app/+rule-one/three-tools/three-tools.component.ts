import { Component, OnInit, Input } from '@angular/core';
import { EmaChartComponent, EMAData } from '../charts';
import { ThreeToolsService } from './three-tools.service';

@Component({
    selector: 'three-tools',
    templateUrl: 'build/+rule-one/three-tools/three-tools.component.html',
    directives: [EmaChartComponent],
    providers: [ThreeToolsService]
})
export class ThreeToolsComponent implements OnInit {
    @Input() companySymbol: string;
    emaData: EMAData[];

    constructor(public threeToolsService: ThreeToolsService ) { }

    ngOnInit() {
        // this.emaData = [
        //     new EMAData(new Date('2014-05-01'), 23.3, 53),
        //     new EMAData(new Date('2014-05-02'), 24.3, 54),
        //     new EMAData(new Date('2014-05-03'), 25.3, 55),
        // ];
        this.threeToolsService.getEMA(this.companySymbol).then(emaData => {
            this.emaData = emaData.map(x => new EMAData(new Date(x.date.toString()), x.price, x.ema));
        });
    }
}