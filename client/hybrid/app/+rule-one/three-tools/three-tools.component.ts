import { Component, OnInit, Input } from '@angular/core';
import { EmaChartComponent, EMAData, MacdChartComponent, MACDData, StochasticChartComponent, StochasticData } from '../charts';
import { ThreeToolsService } from './three-tools.service';

@Component({
    selector: 'three-tools',
    templateUrl: 'build/+rule-one/three-tools/three-tools.component.html',
    directives: [EmaChartComponent, MacdChartComponent, StochasticChartComponent],
    providers: [ThreeToolsService]
})
export class ThreeToolsComponent implements OnInit {
    @Input() companySymbol: string;
    emaData: EMAData[];
    macdData: MACDData[];
    stochasticData: StochasticData[];

    constructor(public threeToolsService: ThreeToolsService ) { }

    ngOnInit() {
        this.threeToolsService.getEMA(this.companySymbol).then(data => {
            this.emaData = data.map(x => new EMAData(new Date(x.date.toString()), x.price, x.ema));
        });
        this.threeToolsService.getMACD(this.companySymbol).then(data => {
            this.macdData = data.map(x => new MACDData(new Date(x.date.toString()), x.macd, x.signal));
        });
        this.threeToolsService.getStochastic(this.companySymbol).then(data => {
            this.stochasticData = data.map(x => new StochasticData(new Date(x.date.toString()), x.percentK, x.percentD));
        });
    }
}