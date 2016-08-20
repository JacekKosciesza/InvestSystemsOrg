"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var meaning_area_1 = require('./meaning-area');
var MeaningAreaView = (function (_super) {
    __extends(MeaningAreaView, _super);
    function MeaningAreaView(meaningArea) {
        _super.call(this);
        this.id = meaningArea.id;
        this.name = meaningArea.name;
        this.type = meaningArea.type;
        this.subtype = meaningArea.subtype;
        this.isEdited = false;
    }
    return MeaningAreaView;
}(meaning_area_1.MeaningArea));
exports.MeaningAreaView = MeaningAreaView;
//# sourceMappingURL=meaning-area-view.js.map