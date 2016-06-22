"use strict";
var meaning_circle_type_1 = require('./meaning-circle-type');
var meaning_circle_subtype_1 = require('./meaning-circle-subtype');
var InMemoryDataService = (function () {
    function InMemoryDataService() {
    }
    InMemoryDataService.prototype.createDb = function () {
        var areas = [
            // Passion
            { id: 1, name: 'Children and family', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 2, name: 'Reading', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 3, name: 'Traveling', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 4, name: 'Animals', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 5, name: 'Theater', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 6, name: 'Teaching', type: meaning_circle_type_1.MeaningCircleType.Passion, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            // Talent
            { id: 7, name: 'Computers', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 8, name: 'Working with people', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 9, name: 'Teaching/training', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 10, name: 'Writing', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 11, name: 'Being a perent', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            { id: 12, name: 'Planning and organizing', type: meaning_circle_type_1.MeaningCircleType.Talent, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None },
            // Money (In)
            { id: 13, name: 'Teacher', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.In },
            { id: 14, name: 'Trainer', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.In },
            // Money (Out)
            { id: 15, name: 'Kids, clothes and toy stores', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.Out },
            { id: 16, name: 'Disney World', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.Out },
            { id: 17, name: 'Computer stores', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.Out },
            { id: 18, name: 'Theater and bookstores', type: meaning_circle_type_1.MeaningCircleType.Money, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.Out },
        ];
        return { areas: areas };
    };
    return InMemoryDataService;
}());
exports.InMemoryDataService = InMemoryDataService;
//# sourceMappingURL=in-memory-circle-data.service.js.map