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
    constructor(public type?: WebsiteType, public link?: string) { }

    public get icon(): string {
        switch (this.type) {
            case WebsiteType.Home:
                return this.varToEnumStringVal(this.type, WebsiteType);
            default:
                return `logo-${this.varToEnumStringVal(this.type, WebsiteType).toLowerCase()}`;
        }
    }

    varToEnumStringVal(value: any, enumerator: any): string {
        var en: { [index: string]: any } = enumerator;

        if (!isNaN(parseInt(value)))
            return en[value];

        var num = en[value];

        return en[num];
    }
}