import { Subsector } from './subsector'

export class Sector {
    constructor(name: string, subsectors: Subsector[]) {
        this.name = name;
        this.subsectors = subsectors;
    }

    name: string;
    subsectors: Subsector[];
}