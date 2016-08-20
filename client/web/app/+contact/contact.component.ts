import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { AngularFire, FirebaseListObservable } from 'angularfire2';

import { MD_BUTTON_DIRECTIVES } from '@angular2-material/button';
import { MD_CARD_DIRECTIVES } from '@angular2-material/card';
import { MD_ICON_DIRECTIVES } from '@angular2-material/icon/icon';
import { MD_INPUT_DIRECTIVES } from '@angular2-material/input';

import { Message } from './message';

@Component({
    moduleId: module.id,
    selector: 'contact-us',
    templateUrl: 'contact.component.html',
    styleUrls: ['contact.component.css'],
    directives: [MD_BUTTON_DIRECTIVES, MD_CARD_DIRECTIVES, MD_ICON_DIRECTIVES, MD_INPUT_DIRECTIVES]
})
export class ContactComponent implements OnInit {
    message: Message;
    active = true;
    submitted = false;
    messages: FirebaseListObservable<Message[]>;
    constructor(private af: AngularFire) {
        this.message = new Message();
    }

    ngOnInit() {
        this.messages = this.af.database.list('/contact/messages') as FirebaseListObservable<Message[]>;
        this.newMessage();
    }

    newMessage() {
        this.message = new Message();
        this.af.auth.subscribe(auth => {
            this.message.name = auth.auth.displayName;
            this.message.email = auth.auth.email;
            this.active = false;
            setTimeout(() => this.active = true, 0);
        });
    }

    onSubmit() {
        this.submitted = true;
        this.messages.push(this.message);
    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.message); }
}