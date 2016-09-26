import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { EMAData, MACDData, StochasticData } from '../charts';


@Injectable()
export class ThreeToolsService {

    private threeToolsUrl = 'http://localhost:5006/api/threetools';

    constructor(private http: Http) { }

    getEMA(companySymbol: string): Promise<EMAData[]> {
        companySymbol = 'AFI'; // TODO: remove it !!!
        let url = `${this.threeToolsUrl}/ema/${companySymbol}`;
        return this.getData(url);
    }

    getMACD(companySymbol: string): Promise<MACDData[]> {
        companySymbol = 'AFI'; // TODO: remove it !!!
        let url = `${this.threeToolsUrl}/macd/${companySymbol}`;
        return this.getData(url);
    }

    getStochastic(companySymbol: string): Promise<StochasticData[]> {
        companySymbol = 'AFI'; // TODO: remove it !!!
        let url = `${this.threeToolsUrl}/stochastic/${companySymbol}`;
        return this.getData(url);
    }

    private getData(url: string)
    {
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as any)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}