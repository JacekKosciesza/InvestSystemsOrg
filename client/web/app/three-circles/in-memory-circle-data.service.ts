import { MeaningArea } from './meaning-area'
import { MeaningCircleType } from './meaning-circle-type'
import { MeaningCircleSubtype } from './meaning-circle-subtype'

export class InMemoryDataService {
  createDb() {
    let areas: MeaningArea[] = [
     // Passion
     { id: 1, name: 'Children and family', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },
     { id: 2, name: 'Reading', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },
     { id: 3, name: 'Traveling', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },
     { id: 4, name: 'Animals', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },
     { id: 5, name: 'Theater', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },
     { id: 6, name: 'Teaching', type: MeaningCircleType.Passion, subtype: MeaningCircleSubtype.None },

     // Talent
     { id: 7, name: 'Computers', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     { id: 8, name: 'Working with people', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     { id: 9, name: 'Teaching/training', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     { id: 10, name: 'Writing', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     { id: 11, name: 'Being a perent', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     { id: 12, name: 'Planning and organizing', type: MeaningCircleType.Talent, subtype: MeaningCircleSubtype.None },
     
     // Money (In)
     { id: 13, name: 'Teacher', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.In },
     { id: 14, name: 'Trainer', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.In },

     // Money (Out)
     { id: 15, name: 'Kids, clothes and toy stores', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.Out },
     { id: 16, name: 'Disney World', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.Out },
     { id: 17, name: 'Computer stores', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.Out },
     { id: 18, name: 'Theater and bookstores', type: MeaningCircleType.Money, subtype: MeaningCircleSubtype.Out },
    ];
    return {areas};
  }
}