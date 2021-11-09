#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["the-elevator/the-elevator.csproj", "the-elevator/"]
RUN dotnet restore "the-elevator/the-elevator.csproj"
COPY . .
WORKDIR "/src/the-elevator"
RUN dotnet build "the-elevator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "the-elevator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "the-elevator.dll"]