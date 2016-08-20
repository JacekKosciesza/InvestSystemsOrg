"use strict";
var leaders_component_1 = require('./leaders.component');
var leaders_list_component_1 = require('./leaders-list.component');
exports.LeadersRoutes = [
    {
        path: 'leaders',
        component: leaders_component_1.LeadersComponent,
        children: [
            {
                path: '',
                component: leaders_list_component_1.LeadersListComponent
            }
        ]
    }
];
//# sourceMappingURL=leaders.routes.js.map