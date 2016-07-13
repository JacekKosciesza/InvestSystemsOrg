"use strict";
var router_1 = require('@angular/router');
var dashboard_component_1 = require('./+dashboard/dashboard.component');
var companies_routes_1 = require('./+companies/companies.routes');
var stocks_routes_1 = require('./+stocks/stocks.routes');
var rule_one_notes_component_1 = require('./notes/rule-one-notes.component');
var three_circles_component_1 = require('./three-circles/three-circles.component');
var team_component_1 = require('./+about/team.component');
var contact_component_1 = require('./+contact/contact.component');
var brokers_component_1 = require('./+brokers/brokers.component');
exports.AppRoutes = [
    {
        path: '',
        component: dashboard_component_1.DashboardComponent
    }
].concat(companies_routes_1.CompaniesRoutes, stocks_routes_1.StocksRoutes, [
    {
        path: 'notes',
        component: rule_one_notes_component_1.RuleOneNotes
    },
    {
        path: 'three-circles',
        component: three_circles_component_1.ThreeCirclesComponent
    },
    {
        path: 'about/team',
        component: team_component_1.TeamComponent
    },
    {
        path: 'contact',
        component: contact_component_1.ContactComponent
    },
    {
        path: 'brokers',
        component: brokers_component_1.BrokersComponent
    },
]);
exports.APP_ROUTER_PROVIDER = router_1.provideRouter(exports.AppRoutes);
//# sourceMappingURL=app.routes.js.map