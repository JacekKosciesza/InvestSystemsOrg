import { Injectable }    from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Meaning } from './meaning.model';


@Injectable()
export class MeaningService {

    private meaningUrl = 'http://localhost:5006/api/meaning';

    constructor(private http: Http) { }

    getMeaning(companySymbol: string, userId: string): Promise<Meaning> {
        let url = `${this.meaningUrl}/${companySymbol}/${userId}`;
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