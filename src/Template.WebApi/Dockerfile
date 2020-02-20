FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Template.WebApi/Template.WebApi.csproj", "src/Template.WebApi/"]
RUN dotnet restore "src/Template.WebApi/Template.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Template.WebApi"
RUN dotnet build "Template.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.WebApi.dll"]
