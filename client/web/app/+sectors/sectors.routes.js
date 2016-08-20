"use strict";
var sectors_component_1 = require('./sectors.component');
var sectors_list_component_1 = require('./sectors-list.component');
exports.SectorsRoutes = [
    {
        path: 'sectors',
        component: sectors_component_1.SectorsComponent,
        children: [
            {
                path: '',
                component: sectors_list_component_1.SectorsListComponent
            }
        ]
    }
];
//# sourceMappingURL=sectors.routes.js.map