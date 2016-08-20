"use strict";
var glossary_component_1 = require('./glossary.component');
var terms_list_component_1 = require('./terms-list.component');
exports.GlossaryRoutes = [
    {
        path: 'glossary',
        component: glossary_component_1.GlossaryComponent,
        children: [
            {
                path: '',
                component: terms_list_component_1.TermsListComponent
            }
        ]
    }
];
//# sourceMappingURL=glossary.routes.js.map