"use strict";
exports.ADD_AREA = 'ADD_AREA';
exports.REMOVE_AREA = 'REMOVE_AREA';
/*
{
    type: string,
    payload? any
}
*/
exports.areasReducer = function (state, action) {
    if (state === void 0) { state = []; }
    switch (action.type) {
        case exports.ADD_AREA:
            return state.concat([
                action.payload
            ]);
        case exports.REMOVE_AREA:
            return state.filter(function (area) { return area.id !== action.payload; });
        default:
            return state;
    }
};
//# sourceMappingURL=area.reducer.js.map