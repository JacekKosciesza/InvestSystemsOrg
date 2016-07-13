import { Injectable } from '@angular/core';

import { Headers, Http } from '@angular/http';

@Injectable()
export class YahooFinanceService {

    constructor(private http: Http) { }

    HelloYQL() {
        var BASE_URL = 'http://query.yahooapis.com/v1/public/yql?q='
        var yql_import = "env 'store://datatables.org/alltableswithkeys';";
        var yql_query = 'select * from yahoo.finance.quote where symbol in ("YHOO","GOOG","MSFT")';
        var yql_extra = '&format=json';
        var query_str_final = `${BASE_URL}${yql_import}${yql_query}${yql_extra}`;
        return this.http.get(query_str_final)
               .toPromise()
               .then(response => response.json());
    }
}