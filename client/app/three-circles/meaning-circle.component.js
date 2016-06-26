"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var Subject_1 = require('rxjs/Subject');
require('rxjs/add/operator/debounceTime');
require('rxjs/add/operator/distinctUntilChanged');
require('rxjs/add/operator/switchMap');
require('rxjs/add/operator/retry');
var meaning_circle_type_1 = require('./meaning-circle-type');
var meaning_circle_subtype_1 = require('./meaning-circle-subtype');
var meaning_area_view_1 = require('./meaning-area-view');
var circle_data_service_1 = require('./circle-data.service');
var MeaningCircleComponent = (function () {
    function MeaningCircleComponent(circleDataService) {
        var _this = this;
        this.circleDataService = circleDataService;
        this.addArea = new core_1.EventEmitter();
        this.suggestionsStream = new Subject_1.Subject();
        this.suggestions = this.suggestionsStream
            .debounceTime(300)
            .distinctUntilChanged()
            .switchMap(function (term) { return _this.circleDataService.suggest(term).retry(3); });
    }
    MeaningCircleComponent.prototype.add = function (name) {
        if (name) {
            var area = { id: 0, name: name, type: this.type, subtype: meaning_circle_subtype_1.MeaningCircleSubtype.None, isEdited: false };
            this.addArea.emit(area);
            this.circleDataService.save(area);
        }
    };
    MeaningCircleComponent.prototype.delete = function (area) {
        var index = this.areas.findIndex(function (a) { return a === area; });
        if (index > -1) {
            this.areas.splice(index, 1);
        }
    };
    MeaningCircleComponent.prototype.suggest = function (term) {
        this.suggestionsStream.next(term);
    };
    MeaningCircleComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.circleDataService.getAreas(this.type)
            .then(function (heroes) { return _this.areas = heroes.map(function (a) { return new meaning_area_view_1.MeaningAreaView(a); }); });
    };
    MeaningCircleComponent.prototype.ngOnChanges = function (changes) {
        //console.log('ngOnChanges');
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], MeaningCircleComponent.prototype, "type", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], MeaningCircleComponent.prototype, "addArea", void 0);
    MeaningCircleComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'meaning-circle',
            templateUrl: 'meaning-circle.component.html',
            styleUrls: ['meaning-circle.component.css']
        }), 
        __metadata('design:paramtypes', [circle_data_service_1.CircleDataService])
    ], MeaningCircleComponent);
    return MeaningCircleComponent;
}());
exports.MeaningCircleComponent = MeaningCircleComponent;
//# sourceMappingURL=meaning-circle.component.js.map