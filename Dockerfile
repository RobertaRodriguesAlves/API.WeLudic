#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0.16-jammy-amd64 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0.408-jammy-amd64 AS build
WORKDIR /src
COPY ["/src/WeLudic.PublicApi/WeLudic.PublicApi.csproj", "WeLudic.PublicApi/"]
COPY ["/src/WeLudic.Application/WeLudic.Application.csproj", "WeLudic.Application/"]
COPY ["/src/WeLudic.Domain/WeLudic.Domain.csproj", "WeLudic.Domain/"]
COPY ["/src/WeLudic.Shared/WeLudic.Shared.csproj", "WeLudic.Shared/"]
COPY ["/src/WeLudic.Infrastructure/WeLudic.Infrastructure.csproj", "WeLudic.Infrastructure/"]
COPY ["/tests/WeLudic.Tests/WeLudic.Tests.csproj", "WeLudic.Tests/"]

WORKDIR "/src/WeLudic.PublicApi"
RUN dotnet remove reference ../../../WeLudic.Tests/WeLudic.Tests.csproj
RUN dotnet add reference ../WeLudic.Tests/WeLudic.Tests.csproj

RUN dotnet restore "/src/WeLudic.PublicApi/WeLudic.PublicApi.csproj"
COPY . .

RUN dotnet build "WeLudic.PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeLudic.PublicApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeLudic.PublicApi.dll"]