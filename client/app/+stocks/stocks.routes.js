"use strict";
var auth_guard_1 = require('../auth.guard');
var stocks_component_1 = require('./stocks.component');
var stocks_list_component_1 = require('./stocks-list.component');
var stock_create_component_1 = require('./stock-create.component');
var stock_detail_component_1 = require('./stock-detail.component');
var stock_edit_component_1 = require('./stock-edit.component');
exports.StocksRoutes = [
    {
        path: 'stock-exchanges',
        component: stocks_component_1.StocksComponent,
        children: [
            {
                path: '',
                component: stocks_list_component_1.StocksListComponent
            },
            {
                path: 'create',
                component: stock_create_component_1.StockCreateComponent,
                canActivate: [auth_guard_1.AuthGuard]
            },
            {
                path: ':id',
                component: stock_detail_component_1.StockDetailComponent
            },
            {
                path: ':id/edit',
                component: stock_edit_component_1.StockEditComponent,
                canActivate: [auth_guard_1.AuthGuard]
            }
        ]
    }
];
//# sourceMappingURL=stocks.routes.js.map