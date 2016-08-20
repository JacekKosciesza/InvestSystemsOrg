import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';

declare var google: any;

@Injectable()
export class ChartsService {
    loadCalled: boolean = false;

     // Observable boolean sources
    private chartsLoadedSource = new Subject<boolean>();

    // Observable boolean streams
    chartsLoaded$ = this.chartsLoadedSource.asObservable();

    load() {
        if (!this.loadCalled) {
            google.charts.load('current', { 'packages': ['line'] });
            google.charts.setOnLoadCallback(this.onChartsLoaded.bind(this));
            this.loadCalled = true;
        }
    }

    onChartsLoaded() {
        this.chartsLoadedSource.next(true);
    }
}