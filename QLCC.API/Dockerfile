#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QLCC.API/QLCC.csproj", "."]
RUN dotnet restore
# RUN dotnet restore "QLCC.API/QLCC.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "QLCC.API/QLCC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QLCC.API/QLCC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "QLCC.dll"]
