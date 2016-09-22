import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Company } from './company.model';


@Injectable()
export class CompanyService {

    private companiesUrl = 'http://localhost:5002/api/companies';

    constructor(private http: Http) { }

    getCompanies(page: number = 1, q: string = null): Promise<any> {
        let url = `${this.companiesUrl}?page=${page}`;
        if (q) {
            url += `&q=${q}`;
        }
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