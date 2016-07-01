import { Injectable } from '@angular/core';

import { StockExchange } from './stock-exchange';

@Injectable()
export class StockService {

    constructor() { }

    // https://en.wikipedia.org/wiki/Stock_exchange
    stocks: StockExchange[] = [
        {
            "id": "Nasdaq",
            "name": "Nasdaq",
            "website": "http://www.nasdaq.com/",
        },
        {
            "id": "NYSE",
            "name": "New York Stock Exchange",
            "website": "https://www.nyse.com/",
        },
        {
            "id": "LSEG",
            "name": "London Stock Exchange Group",
            "website": "http://www.lseg.com/",
        },
        {
            "id": "JPX",
            "name": "Japan Exchange Group",
            "website": "http://www.jpx.co.jp/",
        },
        {
            "id": "SSE",
            "name": "Shanghai Stock Exchange",
            "website": "http://www.sse.com.cn/",
        },
        {
            "id": "HKEX", // SEHK?
            "name": "Hong Kong Stock Exchange",
            "website": "http://www.hkex.com.hk/",
        },
        {
            "id": "Euronext",
            "name": "Euronext",
            "website": "https://www.euronext.com/",
        },
        {
            "id": "SZSE",
            "name": "Shenzhen Stock Exchange",
            "website": "http://www.szse.cn/",
        },
        {
            "id": "TMX",
            "name": "TMX Group",
            "website": "http://www.tmx.com/",
        },
        {
            "id": "Deutsche_Borse",
            "name": "Deutsche Börse",
            "website": "http://deutsche-boerse.com",
        },
        {
            "id": "BSE",
            "name": "Bombay Stock Exchange",
            "website": "http://www.bseindia.com/",
        },
        {
            "id": "NSE",
            "name": "National Stock Exchange of India",
            "website": "http://www.nseindia.com/",
        },
        {
            "id": "SIX_Swiss_Exchange",
            "name": "SIX Swiss Exchange",
            "website": "http://www.six-swiss-exchange.com/",
        },
        {
            "id": "ASX",
            "name": "Australian Securities Exchange",
            "website": "http://www.asx.com.au/",
        },
        {
            "id": "KRX",
            "name": "Korea Exchange",
            "website": "http://www.krx.co.kr/",
        },
        {
            "id": "OMX",
            "name": "OMX",
            "website": "http://www.omxnordicexchange.com/",
        },
        {
            "id": "JSE",
            "name": "JSE",
            "website": "http://www.jse.co.za/",
        },
        {
            "id": "BME",
            "name": "Bolsas y Mercados Españoles",
            "website": "http://www.bolsasymercados.es/",
        },
        {
            "id": "TWSE",
            "name": "Taiwan Stock Exchange",
            "website": "http://www.twse.com.tw",
        },
        {
            "id": "BM_F_Bovespa",
            "name": "BM&F Bovespa",
            "website": "http://www.bmfbovespa.com.br/",
        },
    ]

    getCompanies(): StockExchange[] {
        return this.stocks;
    }

    getCompany(id: string) {
        return this.stocks.filter(company => company.id === id)[0];
    }
}