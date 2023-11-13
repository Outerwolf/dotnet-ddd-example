FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HomeIoT/HomeIoT.csproj", "HomeIoT/"]
RUN dotnet restore "HomeIoT/HomeIoT.csproj"
COPY . .
WORKDIR "/src/HomeIoT"
RUN dotnet build "HomeIoT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeIoT.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeIoT.dll"]
