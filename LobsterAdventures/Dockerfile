FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
#COPY bin/release/net6.0/Debug/ App/
#ENV ASPNETCORE_HTTP_PORT https://*:5000
#ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development
#EXPOSE 80
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY LobsterAdventures/*.csproj ./LobsterAdventures/
COPY LobsterAdventures.BLL/*.csproj ./LobsterAdventures.BLL/
COPY LobsterAdventures.DAL/*.csproj ./LobsterAdventures.DAL/
COPY LobsterAdventures.Models/*.csproj ./LobsterAdventures.Models/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY LobsterAdventures/. ./LobsterAdventures/
COPY LobsterAdventures.BLL/. ./LobsterAdventures.BLL/
COPY LobsterAdventures.DAL/. ./LobsterAdventures.DAL/
COPY LobsterAdventures.Models/. ./LobsterAdventures.Models/
#
WORKDIR /app/LobsterAdventures
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app/LobsterAdventures
#
COPY --from=build /app/LobsterAdventures/out ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "/app/LobsterAdventures/LobsterAdventures.dll"]