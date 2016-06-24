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
var http_1 = require('@angular/http');
require('rxjs/add/operator/toPromise');
require('rxjs/add/operator/map');
require('rxjs/add/operator/mergeMap');
//import 'rxjs/add/operator/flatMap';
require('rxjs/add/operator/filter');
var meaning_circle_type_1 = require('./meaning-circle-type');
var CircleDataService = (function () {
    function CircleDataService(http) {
        this.http = http;
        this.areasUrl = 'app/areas'; // URL to web api
    }
    CircleDataService.prototype.getAreas = function (type) {
        return this.http.get(this.areasUrl)
            .toPromise()
            .then(function (response) { return response.json().data; })
            .then(function (data) {
            if (type) {
                return data.filter(function (x) { return x.type === meaning_circle_type_1.MeaningCircleType[type]; });
            }
            return data;
        })
            .catch(this.handleError);
    };
    CircleDataService.prototype.suggest = function (term, type) {
        return this.http.get(this.areasUrl)
            .map(function (r) { return r.json().data // get payload, so array of areas
            .map(function (x) { return x.name; }) // array of names
            .filter(function (x) { return x.toLocaleLowerCase().indexOf(term.toLocaleLowerCase()) > -1; }); } // names that contains term (as substring)
         // names that contains term (as substring)
        );
    };
    CircleDataService.prototype.getArea = function (id) {
        return this.getAreas()
            .then(function (areas) { return areas.filter(function (area) { return area.id === id; })[0]; });
    };
    CircleDataService.prototype.save = function (area) {
        if (area.id) {
            return this.put(area);
        }
        return this.post(area);
    };
    CircleDataService.prototype.delete = function (area) {
        var headers = new http_1.Headers();
        headers.append('Content-Type', 'application/json');
        var url = this.areasUrl + "/" + area.id;
        return this.http
            .delete(url, headers)
            .toPromise()
            .catch(this.handleError);
    };
    // Add new Area
    CircleDataService.prototype.post = function (area) {
        var headers = new http_1.Headers({
            'Content-Type': 'application/json' });
        return this.http
            .post(this.areasUrl, JSON.stringify(area), { headers: headers })
            .toPromise()
            .then(function (res) { return res.json().data; })
            .catch(this.handleError);
    };
    // Update existing Area
    CircleDataService.prototype.put = function (area) {
        var headers = new http_1.Headers();
        headers.append('Content-Type', 'application/json');
        var url = this.areasUrl + "/" + area.id;
        return this.http
            .put(url, JSON.stringify(area), { headers: headers })
            .toPromise()
            .then(function () { return area; })
            .catch(this.handleError);
    };
    CircleDataService.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    CircleDataService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], CircleDataService);
    return CircleDataService;
}());
exports.CircleDataService = CircleDataService;
//# sourceMappingURL=circle-data.service.js.map