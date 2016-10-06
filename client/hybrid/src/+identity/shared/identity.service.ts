import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Token } from './'

import 'rxjs/add/operator/toPromise';

@Injectable()
export class IdentityService {
    public userInfo: any;
    public token: Token;

    private baseUrl = 'http://localhost:5000/'
    private tokenUrl = `${this.baseUrl}connect/token`;
    private userInfoUrl = `${this.baseUrl}connect/userinfo`;
    private headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });

    constructor(private http: Http) { }

    getToken(username: string, password: string): Promise<Token> {
        var body = `username=${username}&password=${password}&grant_type=password&scope=openid roles profile email`;

        return this.http.post(this.tokenUrl, body, { headers: this.headers })
            .toPromise()
            .then(response => { this.token = response.json() as Token; return this.token; })
            .catch(this.handleError);
    }

    getUserInfo(): Promise<any> {
        return this.http.get(this.userInfoUrl)
            .toPromise()
            .then(response => { this.userInfo = response.json(); return this.userInfo; })
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}