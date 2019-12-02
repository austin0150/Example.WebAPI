FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80 3306

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Example.WebAPI/Example.WebAPI.csproj", "src/Example.WebAPI/"]
COPY ["src/Example.Business/Example.Business.csproj", "src/Example.Business/"]
COPY ["src/Example.DataAccess/Example.DataAccess.csproj", "src/Example.DataAccess/"]
#COPY /src/apidb.dbcfg ./app/
RUN dotnet restore "src/Example.WebAPI/Example.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Example.WebAPI"
RUN dotnet build "Example.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.WebAPI.dll"]
COPY ./apidb.dbcfg /app/
