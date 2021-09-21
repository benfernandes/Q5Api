# Q5Api - Zero-to-Hero

## Pre-requisites
- Docker (download [here](https://www.docker.com/products/docker-desktop))
- .NET 5 (download [here](https://dotnet.microsoft.com/download/dotnet/5.0))
- Entity Framework Core Tools (download [here](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools))

## Setting up for development
1. Clone the repo locally
2. Open the repository folder
3. Run `docker-compose up` to start a Docker container for the MSSQL database
4. Run `dotnet ef database update` to apply database migrations
5. Run `dotnet run` to start the API server

## Possible issues
- Currently, the database runs inside Docker but the API server runs outside, so you may experience some connection difficulties between the two.
