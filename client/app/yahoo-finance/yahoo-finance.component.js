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
var yahoo_finance_service_1 = require('./yahoo-finance.service');
var YahooFinanceComponent = (function () {
    function YahooFinanceComponent(yfs) {
        this.yfs = yfs;
    }
    YahooFinanceComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.yfs.Current("MENT").then(function (result) { return _this.current = result; });
        this.yfs.Historical("MENT").then(function (result) { return _this.historical = result; });
        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(this.drawCurveTypes);
    };
    YahooFinanceComponent.prototype.drawCurveTypes = function () {
        var data = new google.visualization.DataTable();
        data.addColumn('number', 'X');
        data.addColumn('number', 'Dogs');
        data.addColumn('number', 'Cats');
        data.addRows([
            [0, 0, 0], [1, 10, 5], [2, 23, 15], [3, 17, 9], [4, 18, 10], [5, 9, 5],
            [6, 11, 3], [7, 27, 19], [8, 33, 25], [9, 40, 32], [10, 32, 24], [11, 35, 27],
            [12, 30, 22], [13, 40, 32], [14, 42, 34], [15, 47, 39], [16, 44, 36], [17, 48, 40],
            [18, 52, 44], [19, 54, 46], [20, 42, 34], [21, 55, 47], [22, 56, 48], [23, 57, 49],
            [24, 60, 52], [25, 50, 42], [26, 52, 44], [27, 51, 43], [28, 49, 41], [29, 53, 45],
            [30, 55, 47], [31, 60, 52], [32, 61, 53], [33, 59, 51], [34, 62, 54], [35, 65, 57],
            [36, 62, 54], [37, 58, 50], [38, 55, 47], [39, 61, 53], [40, 64, 56], [41, 65, 57],
            [42, 63, 55], [43, 66, 58], [44, 67, 59], [45, 69, 61], [46, 69, 61], [47, 70, 62],
            [48, 72, 64], [49, 68, 60], [50, 66, 58], [51, 65, 57], [52, 67, 59], [53, 70, 62],
            [54, 71, 63], [55, 72, 64], [56, 73, 65], [57, 75, 67], [58, 70, 62], [59, 68, 60],
            [60, 64, 56], [61, 60, 52], [62, 65, 57], [63, 67, 59], [64, 68, 60], [65, 69, 61],
            [66, 70, 62], [67, 72, 64], [68, 75, 67], [69, 80, 72]
        ]);
        var options = {
            hAxis: {
                title: 'Time'
            },
            vAxis: {
                title: 'Popularity'
            },
            series: {
                1: { curveType: 'function' }
            }
        };
        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    };
    YahooFinanceComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'yahoo-finance',
            templateUrl: 'yahoo-finance.component.html',
            styleUrls: ['yahoo-finance.component.css'],
            providers: [yahoo_finance_service_1.YahooFinanceService]
        }), 
        __metadata('design:paramtypes', [yahoo_finance_service_1.YahooFinanceService])
    ], YahooFinanceComponent);
    return YahooFinanceComponent;
}());
exports.YahooFinanceComponent = YahooFinanceComponent;
//# sourceMappingURL=yahoo-finance.component.js.map