FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ApiTemplate/ ApiTemplate/
COPY Common/ Common/
COPY Entities/ Entities/
COPY Repository/ Repository/
COPY Services/ Services/

RUN dotnet restore ./ApiTemplate -nowarn:msb3202,nu1503

# Copy everything else and build
COPY . ./
RUN dotnet publish ./ApiTemplate -c Release -o /app

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "ApiTemplate.dll"]