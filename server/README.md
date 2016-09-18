# Server (backend)

### Folder structure
    ..
    ├── Companies               # Companies microservice
    ├── Email                   # Email microservice
    ├── Financials              # Financials microservice
    ├── Gamification            # Gamification microservice
    ├── Gateway                 # Gateway microservice
    ├── Identity                # Identity microservice
    ├── InvestSystemsOrg        # Service Fabric project
    ├── Portfolio               # Portfolio microservice
    ├── RuleOne                 # Rule #1 microservice
    ├── Shared                  # Shared code
    ├── StockQuotes             # StockQuotes microservice
    ├── Watchlist               # Watchlist code
    └── InvestSystemsOrg.sln    # Solution with all microservices

### Microservices

| Name             | Description                         | URI                    |
|------------------|-------------------------------------|------------------------|
| Companies        |                                     | http://localhost:5001  |
| Email            |                                     | http://localhost:5002  |
| Financials       |                                     | http://localhost:5003  |
| Gamification     |                                     | http://localhost:5004  |
| Gateway          |                                     | http://localhost:5005  |
| Identity         |                                     | http://localhost:5006  |
| Portfolio        |                                     | http://localhost:5007  |
| RuleOne          |                                     | http://localhost:5008  |
| StockQuotes      |                                     | http://localhost:5000  |
| Watchlist        |                                     | http://localhost:5010  |

### Technologies

* ASP.NET Core
* Entity Framework Core
* Swashbuckle
* xUnit.net
* Service Fabric