import { Component, OnInit, Input } from '@angular/core';
import { EMAData, MACDData, StochasticData } from '../charts';
import { ThreeToolsService } from './three-tools.service';

@Component({
    selector: 'three-tools',
    templateUrl: 'three-tools.component.html'
})
export class ThreeToolsComponent implements OnInit {
    @Input() companySymbol: string;
    public emaData: EMAData[];
    public macdData: MACDData[];
    public stochasticData: StochasticData[];

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