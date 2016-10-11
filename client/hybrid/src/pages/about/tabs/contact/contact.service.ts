import { Injectable } from '@angular/core';

import { Message } from './message';

@Injectable()
export class ContactService {
    constructor() { }

    send(message: Message): Promise<any> {
        let delay = new Promise(r => setTimeout(r, 1000));
        return delay;
    }
}