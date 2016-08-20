"use strict";
var core_1 = require('@angular/core');
exports.APP_CONFIG = new core_1.OpaqueToken('app.config');
exports.appConfig = function (config) {
    return core_1.provide(exports.APP_CONFIG, { useValue: config });
};
//# sourceMappingURL=app-config.provider.js.map