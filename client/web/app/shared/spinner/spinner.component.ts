import {Component, OnDestroy, OnInit} from '@angular/core';
import { Subscription } from 'rxjs/Rx';

import { MD_PROGRESS_CIRCLE_DIRECTIVES  } from '@angular2-material/progress-circle';

import { ISpinnerState, SpinnerService } from './spinner.service';

@Component({
    selector: 'loading-spinner',
    template: `<md-spinner *ngIf="visible"></md-spinner>`,
    directives: [MD_PROGRESS_CIRCLE_DIRECTIVES]
})

export class SpinnerComponent implements OnDestroy, OnInit {
    visible = false;

    private _spinnerStateChanged: Subscription;

    constructor(private _spinnerService: SpinnerService) { }

    ngOnInit() {
        this._spinnerStateChanged = this._spinnerService.spinnerState
            .subscribe((state: ISpinnerState) => this.visible = state.show);
    }

    ngOnDestroy() {
        this._spinnerStateChanged.unsubscribe();
    }
}