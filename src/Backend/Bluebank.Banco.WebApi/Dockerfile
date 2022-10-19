#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Backend/Bluebank.Banco.WebApi/Bluebank.Banco.WebApi.csproj", "src/Backend/Bluebank.Banco.WebApi/"]
COPY ["src/Backend/Bluebank.Banco.Bootstrap/Bluebank.Banco.Bootstrap.csproj", "src/Backend/Bluebank.Banco.Bootstrap/"]
COPY ["src/Backend/Bluebank.Banco.Infraestructure.Data/Bluebank.Banco.Infraestructure.Data.csproj", "src/Backend/Bluebank.Banco.Infraestructure.Data/"]
COPY ["src/Backend/Bluebank.Banco.Aplicacion/Bluebank.Banco.Aplicacion.csproj", "src/Backend/Bluebank.Banco.Aplicacion/"]
COPY ["src/Backend/Bluebank.Banco.Dominio/Bluebank.Banco.Dominio.csproj", "src/Backend/Bluebank.Banco.Dominio/"]
COPY ["src/Backend/Bluebank.Banco.Infraestructure.Logging/Bluebank.Banco.Infraestructure.Logging.csproj", "src/Backend/Bluebank.Banco.Infraestructure.Logging/"]
RUN dotnet restore "src/Backend/Bluebank.Banco.WebApi/Bluebank.Banco.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Backend/Bluebank.Banco.WebApi"
RUN dotnet build "Bluebank.Banco.WebApi.csproj" -c Release -o /app/build

FROM build as test
WORKDIR /src/test/BlueBank.Banca.Pruebas
RUN dotnet test

FROM build AS publish
RUN dotnet publish "Bluebank.Banco.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bluebank.Banco.WebApi.dll"]