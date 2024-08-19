FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FormulaAirline.TicketProcessing/FormulaAirline.TicketProcessing.csproj", "FormulaAirline.TicketProcessing/"]
RUN dotnet restore "FormulaAirline.TicketProcessing/FormulaAirline.TicketProcessing.csproj"
COPY . .
WORKDIR "/src/FormulaAirline.TicketProcessing"
RUN dotnet build "FormulaAirline.TicketProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FormulaAirline.TicketProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FormulaAirline.TicketProcessing.dll"]
