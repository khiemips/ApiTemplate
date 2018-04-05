FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ApiTemplate.sln ./
COPY ApiTemplate/ApiTemplate.csproj ApiTemplate/
COPY Common/Common.csproj Common/
COPY Services/Services.csproj Services/
COPY Repository/Repository.csproj Repository/
COPY Entities/Entities.csproj Entities/

RUN dotnet restore -nowarn:msb3202,nu1503

COPY . .
WORKDIR /src/ApiTemplate
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiTemplate.dll"]
