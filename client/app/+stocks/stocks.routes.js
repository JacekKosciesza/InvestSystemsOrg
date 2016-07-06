"use strict";
var stocks_component_1 = require('./stocks.component');
var stocks_list_component_1 = require('./stocks-list.component');
var stock_detail_component_1 = require('./stock-detail.component');
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
                path: ':id',
                component: stock_detail_component_1.StockDetailComponent
            }
        ]
    }
];
//# sourceMappingURL=stocks.routes.js.map