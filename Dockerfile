FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
LABEL Echo.Equipment.Api=true
WORKDIR /app
EXPOSE 80
COPY ./ ./
RUN dotnet restore Echo.Equipment.Api.sln
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as base
LABEL Echo.Equipment.Api=true
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Echo.Equipment.Api.dll"]