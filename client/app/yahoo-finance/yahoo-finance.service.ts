import { Injectable } from '@angular/core';

import { Headers, Http } from '@angular/http';

import { Quote } from './quote'

@Injectable()
export class YahooFinanceService {
    BASE_URL = 'http://query.yahooapis.com/v1/public/yql?q='
    YQL_IMPORT = "env 'store://datatables.org/alltableswithkeys';";
    YQL_EXTRA = '&format=json';

    constructor(private http: Http) { }

    Current(symbol: string) {
        var yql_query = `select * from yahoo.finance.quote where symbol = "${symbol}"`;
        return this.Get(yql_query);
    }

    Historical(symbol: string) {
        var yql_query = `select * from yahoo.finance.historicaldata where symbol = "${symbol}" and startDate = "2015-07-13" and endDate = "2016-07-13"`;
        return this.Get(yql_query);
    }

    Get(yql_query: string) {
        var query_str_final = `${this.BASE_URL}${this.YQL_IMPORT}${yql_query}${this.YQL_EXTRA}`;
        return this.http.get(query_str_final)
            .toPromise()
            .then(response => response.json().query.results.quote);
    }
}