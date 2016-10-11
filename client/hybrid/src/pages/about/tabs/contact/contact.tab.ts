import { Component, OnInit } from '@angular/core';

import { Message } from './message';
import { ContactService } from './contact.service';
import { ToastService, Toast } from '../../../../services';

@Component({
    selector: 'contact-tab',
    templateUrl: 'contact.tab.html'
})
export class ContactTab implements OnInit {
    public message: Message;
    public active = true;
    public submitted = false;

    constructor(private contactService: ContactService, private toastService: ToastService) { }

    ngOnInit() {
        this.newMessage();
    }

    newMessage() {
        this.message = new Message();
        setTimeout(() => this.active = true, 0);
    }

    onSubmit() {
        this.submitted = true;
        this.contactService.send(this.message).then(() => {
            this.toastService.show(new Toast('Message sent', 3000));
            this.newMessage();
        })
    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.message); }
}