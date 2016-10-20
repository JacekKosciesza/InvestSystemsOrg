import { Injectable } from '@angular/core';

import { Subject } from 'rxjs/Subject';
import { Observable } from "rxjs/Observable";
import { Toast } from './toast';

@Injectable()
export class ToastService {    
    private toastSource = new Subject<Toast>();
    public toasts$ = this.toastSource.asObservable();

    show(toast: Toast) {
        this.toastSource.next(toast);
    }
}