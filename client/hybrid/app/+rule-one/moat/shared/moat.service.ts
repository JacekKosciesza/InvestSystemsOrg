import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Moat } from './moat.model';

@Injectable()
export class MoatService {

    private fiveMoatsUrl = 'http://localhost:5006/api/moats';

    constructor(private http: Http) { }

    getMoat(companySymbol: string): Promise<Moat> {
        let url = `${this.fiveMoatsUrl}/${companySymbol}`;
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