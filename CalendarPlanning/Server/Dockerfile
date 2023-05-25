#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["CalendarPlanning/Server/CalendarPlanning.Server.csproj", "CalendarPlanning/Server/"]
COPY ["CalendarPlanning/Client/CalendarPlanning.Client.csproj", "CalendarPlanning/Client/"]
COPY ["CalendarPlanning/Shared/CalendarPlanning.Shared.csproj", "CalendarPlanning/Shared/"]
RUN dotnet restore "CalendarPlanning/Server/CalendarPlanning.Server.csproj"
COPY . .
WORKDIR "/src/CalendarPlanning/Server"
RUN dotnet build "CalendarPlanning.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalendarPlanning.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalendarPlanning.Server.dll"]