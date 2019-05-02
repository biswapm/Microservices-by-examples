FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 55584
EXPOSE 44379

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY UserIdentity.Api/UserIdentity.Api.csproj UserIdentity.Api/
RUN dotnet restore UserIdentity.Api/UserIdentity.Api.csproj
COPY . .
WORKDIR /src/UserIdentity.Api
RUN dotnet build UserIdentity.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish UserIdentity.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserIdentity.Api.dll"]
