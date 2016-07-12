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
var angularfire2_1 = require('angularfire2');
var button_1 = require('@angular2-material/button');
var card_1 = require('@angular2-material/card');
var icon_1 = require('@angular2-material/icon/icon');
var input_1 = require('@angular2-material/input');
var message_1 = require('./message');
var ContactComponent = (function () {
    function ContactComponent(af) {
        this.af = af;
        this.active = true;
        this.submitted = false;
        this.message = new message_1.Message();
    }
    ContactComponent.prototype.ngOnInit = function () {
        this.messages = this.af.database.list('/contact/messages');
        this.newMessage();
    };
    ContactComponent.prototype.newMessage = function () {
        var _this = this;
        this.message = new message_1.Message();
        this.af.auth.subscribe(function (auth) {
            _this.message.name = auth.auth.displayName;
            _this.message.email = auth.auth.email;
            _this.active = false;
            setTimeout(function () { return _this.active = true; }, 0);
        });
    };
    ContactComponent.prototype.onSubmit = function () {
        this.submitted = true;
        this.messages.push(this.message);
    };
    Object.defineProperty(ContactComponent.prototype, "diagnostic", {
        // TODO: Remove this when we're done
        get: function () { return JSON.stringify(this.message); },
        enumerable: true,
        configurable: true
    });
    ContactComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'contact-us',
            templateUrl: 'contact.component.html',
            styleUrls: ['contact.component.css'],
            directives: [button_1.MD_BUTTON_DIRECTIVES, card_1.MD_CARD_DIRECTIVES, icon_1.MD_ICON_DIRECTIVES, input_1.MD_INPUT_DIRECTIVES]
        }), 
        __metadata('design:paramtypes', [angularfire2_1.AngularFire])
    ], ContactComponent);
    return ContactComponent;
}());
exports.ContactComponent = ContactComponent;
//# sourceMappingURL=contact.component.js.map