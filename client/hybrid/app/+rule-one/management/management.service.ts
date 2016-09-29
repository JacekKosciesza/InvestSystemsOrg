import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Leader } from './leader.model';


@Injectable()
export class ManagementService {

    private managementUrl = 'http://localhost:5006/api/management';

    constructor(private http: Http) { }

    getLeaders(companySymbol: string): Promise<Leader[]> {
        let url = `${this.managementUrl}/${companySymbol}`;
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