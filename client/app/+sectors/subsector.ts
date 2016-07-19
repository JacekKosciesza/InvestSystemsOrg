import { Industry } from './industry'

export class Subsector {
    constructor(name: string, industries: Industry[]) {
        this.name = name;
        this.industries = industries;
    }

    name: string;
    industries: Industry[];
}