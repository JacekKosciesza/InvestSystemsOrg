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
var Logger_1 = require("log4ts/build/Logger");
var LoggerConfig_1 = require("log4ts/build/LoggerConfig");
var BasicLayout_1 = require("log4ts/build/layouts/BasicLayout");
var ConsoleAppender_1 = require("log4ts/build/appenders/ConsoleAppender");
var LogLevel_1 = require("log4ts/build/LogLevel");
var LogService = (function () {
    function LogService() {
        this.layout = new BasicLayout_1.default();
        this.appender = new ConsoleAppender_1.default();
        this.appender.setLayout(this.layout);
        this.config = new LoggerConfig_1.default(this.appender);
        this.config.setLevel(LogLevel_1.LogLevel.ALL);
        this.logger = new Logger_1.default(''); // TODO: tag?
        Logger_1.default.setConfig(this.config);
    }
    LogService.prototype.log = function (message, object, deep) {
        this.logger.log(message, object, deep);
    };
    LogService.prototype.trace = function (message, object, deep) {
        this.logger.trace(message, object, deep);
    };
    LogService.prototype.debug = function (message, object, deep) {
        this.logger.debug(message, object, deep);
    };
    LogService.prototype.info = function (message, object, deep) {
        this.logger.info(message, object, deep);
    };
    LogService.prototype.warn = function (message, object, deep) {
        this.logger.warn(message, object, deep);
    };
    LogService.prototype.error = function (message, object, deep) {
        this.logger.error(message, object, deep);
    };
    LogService.prototype.fatal = function (message, object, deep) {
        this.logger.fatal(message, object, deep);
    };
    LogService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], LogService);
    return LogService;
}());
exports.LogService = LogService;
//# sourceMappingURL=log.service.js.map