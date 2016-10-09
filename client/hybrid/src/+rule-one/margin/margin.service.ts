import { Injectable }    from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Margin } from './margin.model';

@Injectable()
export class MarginService {

    //private marginUrl = 'http://localhost:5006/api/margin'; //'app/margins';

    constructor(private http: Http) { }

    getMargin(companySymbol: string): Promise<Margin> {
        let margin = new Margin();
        margin.stickerPrice = 45;
        margin.marginOfSafety = 22;
        margin.currentPrice = 51;
        return Promise.resolve(margin);

        // let url = `${this.marginUrl}/${companySymbol}`;
        // return this.http.get(url)
        //     .toPromise()
        //     .then(response => response.json() as any)
        //     .catch(this.handleError);
    }

    // private handleError(error: any): Promise<any> {
    //     console.error('An error occurred', error); // for demo purposes only
    //     return Promise.reject(error.message || error);
    // }
}