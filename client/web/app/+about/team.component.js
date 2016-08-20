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
var card_1 = require('@angular2-material/card');
var team_service_1 = require('./team.service');
var TeamComponent = (function () {
    function TeamComponent(teamService, titleService) {
        this.teamService = teamService;
        this.titleService = titleService;
    }
    TeamComponent.prototype.ngOnInit = function () {
        this.team = this.teamService.getTeam();
        this.titleService.setTitle('About Team');
    };
    TeamComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'about-team',
            templateUrl: 'team.component.html',
            styleUrls: ['team.component.css'],
            providers: [team_service_1.TeamService],
            directives: [card_1.MD_CARD_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [team_service_1.TeamService, platform_browser_1.Title])
    ], TeamComponent);
    return TeamComponent;
}());
exports.TeamComponent = TeamComponent;
//# sourceMappingURL=team.component.js.map