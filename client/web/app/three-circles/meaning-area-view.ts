import { MeaningCircleType } from './meaning-circle-type'
import { MeaningArea } from './meaning-area'
import { MeaningCircleSubtype } from './meaning-circle-subtype'


export class MeaningAreaView extends MeaningArea {
    isEdited: boolean;

    constructor(meaningArea: MeaningArea) {
        super();
        this.id = meaningArea.id
        this.name = meaningArea.name
        this.type = meaningArea.type;
        this.subtype = meaningArea.subtype;
        this.isEdited = false;
    }
}