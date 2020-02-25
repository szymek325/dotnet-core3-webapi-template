master
[![Build Status](https://szymek325.visualstudio.com/My%20First%20Project/_apis/build/status/szymek325.dotnet-core3-webapi-template?branchName=master)](https://szymek325.visualstudio.com/My%20First%20Project/_build/latest?definitionId=2&branchName=master)

develop
[![Build Status](https://szymek325.visualstudio.com/My%20First%20Project/_apis/build/status/szymek325.dotnet-core3-webapi-template?branchName=develop)](https://szymek325.visualstudio.com/My%20First%20Project/_build/latest?definitionId=2&branchName=develop)

# dotnet-core3-webapi-template
Starter for .net core 3 rest api with versioning and Swagger

## Run database migration
dotnet tool install --global dotnet-ef --version 3.1.1
dotnet ef migrations add InitDb --project ./src/Template.WebApi/Template.WebApi.csproj --output-dir ./DataAccess/Migrations
dotnet ef database update --project ./src/Template.WebApi/Template.WebApi.csproj
