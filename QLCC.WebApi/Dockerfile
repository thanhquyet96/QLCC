#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["/QLCC.WebApi/QLCC.WebApi.csproj", "/QLCC.WebApi/"]
COPY ["/QLCC.Services/QLCC.Services.csproj", "/QLCC.Services/"]
COPY ["/Service/Service.csproj", "/Service/"]
COPY ["/Common/Common.csproj", "/Common/"]
COPY ["/Repository/Repository.csproj", "/Repository/"]
COPY ["/QLCC.Data/QLCC.Data.csproj", "/QLCC.Data/"]
COPY ["/UnitOfWork/UnitOfWork.csproj", "/UnitOfWork/"]
RUN dotnet restore "/QLCC.WebApi/QLCC.WebApi.csproj"
COPY . .
WORKDIR "/src//QLCC.WebApi"
RUN dotnet build "QLCC.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QLCC.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QLCC.WebApi.dll"]
