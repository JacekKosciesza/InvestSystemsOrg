import { Component, OnInit, Input } from '@angular/core';

import { Website, WebsiteType } from '../shared';

@Component({
    selector: 'social-network',
    template:
    `
        <a *ngFor="let website of websites" href="{{website.link}}}"><ion-icon name="{{icons[website.type]}}"></ion-icon></a> 
    `
})
export class SocialNetworkComponent implements OnInit {
    @Input() websites: Array<Website>;
    icons: { [type: number] : string; };

    constructor() {
        this.icons = {};
        this.icons[WebsiteType.Home] = 'home';
        this.icons[WebsiteType.LinkedIn] = 'logo-linkedin';
        this.icons[WebsiteType.Facebook] = 'logo-facebook';
        this.icons[WebsiteType.Twitter] = 'logo-twitter';
        this.icons[WebsiteType.GooglePlus] = 'logo-googleplus';
        this.icons[WebsiteType.YouTube] = 'logo-youtube';
        this.icons[WebsiteType.Instagram] = 'logo-instagram';
        this.icons[WebsiteType.Pinterest] = 'logo-pinterest';
        this.icons[WebsiteType.Reddit] = 'logo-reddit';
        this.icons[WebsiteType.Vimeo] = 'logo-vimeo';
    }

    ngOnInit() {
    }
}