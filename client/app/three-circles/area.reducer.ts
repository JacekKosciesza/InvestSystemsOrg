import { ActionReducer, Action } from '@ngrx/store';

import { MeaningArea } from './meaning-area'

export const ADD_AREA = 'ADD_AREA';
export const REMOVE_AREA = 'REMOVE_AREA';

/*
{
    type: string,
    payload? any
}
*/
export const areasReducer: ActionReducer<MeaningArea[]> = (state: MeaningArea[] = [], action: Action) => {
    switch(action.type) {        
        case ADD_AREA:
            return [
                ...state,
                action.payload
            ];
        case REMOVE_AREA:
            return state.filter(area => area.id !== action.payload);

        default:
            return state;
    }
}