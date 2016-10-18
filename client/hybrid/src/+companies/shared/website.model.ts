export enum WebsiteType {
    Home = 0,
    LinkedIn,
    Facebook,
    Twitter,
    GooglePlus,
    YouTube,
    Instagram,
    Pinterest,
    Reddit,
    Vimeo
}

export class Website {
    constructor(public type: WebsiteType, public link: string) { }
}