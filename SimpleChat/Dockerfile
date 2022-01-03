FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleChat/SimpleChat.csproj", "SimpleChat/"]
RUN dotnet restore "SimpleChat/SimpleChat.csproj"
COPY . .
WORKDIR "/src/SimpleChat"
RUN dotnet build "SimpleChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleChat.dll"]
