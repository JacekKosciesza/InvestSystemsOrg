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
var platform_browser_1 = require('@angular/platform-browser');
var meaning_circle_component_1 = require('./meaning-circle.component');
var circle_data_service_1 = require('./circle-data.service');
var store_1 = require('@ngrx/store');
var area_reducer_1 = require('./area.reducer');
var ThreeCirclesComponent = (function () {
    function ThreeCirclesComponent(titleService, store) {
        var _this = this;
        this.titleService = titleService;
        this.store = store;
        store
            .select(function (state) { return state.areas; })
            .subscribe(function (areas) {
            _this.areas = areas;
        });
    }
    ThreeCirclesComponent.prototype.ngOnInit = function () {
        this.setTitle('Three Circles | Rule #1');
    };
    ThreeCirclesComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    ThreeCirclesComponent.prototype.onAddArea = function (area) {
        console.log(area);
        this.store.dispatch({ type: area_reducer_1.ADD_AREA, payload: area });
    };
    ThreeCirclesComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'three-circles',
            templateUrl: 'three-circles.component.html',
            styleUrls: ['three-circles.component.css'],
            directives: [meaning_circle_component_1.MeaningCircleComponent],
            providers: [circle_data_service_1.CircleDataService],
            animations: [
                core_1.trigger('flyInOut', [
                    core_1.state('in', core_1.style({ opacity: 1, transform: 'translateX(0)' })),
                    core_1.transition('void => *', [
                        core_1.style({
                            opacity: 0,
                            transform: 'translateX(-100%)'
                        }),
                        core_1.animate('0.2s ease-in')
                    ]),
                    core_1.transition('* => void', [
                        core_1.animate('0.2s 10 ease-out', core_1.style({
                            opacity: 0,
                            transform: 'translateX(100%)'
                        }))
                    ])
                ])
            ]
        }), 
        __metadata('design:paramtypes', [platform_browser_1.Title, store_1.Store])
    ], ThreeCirclesComponent);
    return ThreeCirclesComponent;
}());
exports.ThreeCirclesComponent = ThreeCirclesComponent;
//# sourceMappingURL=three-circles.component.js.map