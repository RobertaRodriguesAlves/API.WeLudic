#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WeLudic.PublicApi/WeLudic.PublicApi.csproj", "src/WeLudic.PublicApi/"]
COPY ["src/WeLudic.Application/WeLudic.Application.csproj", "src/WeLudic.Application/"]
COPY ["src/WeLudic.Domain/WeLudic.Domain.csproj", "src/WeLudic.Domain/"]
COPY ["src/WeLudic.Shared/WeLudic.Shared.csproj", "src/WeLudic.Shared/"]
COPY ["src/WeLudic.Infrastructure/WeLudic.Infrastructure.csproj", "src/WeLudic.Infrastructure/"]
RUN dotnet restore "src/WeLudic.PublicApi/WeLudic.PublicApi.csproj"
COPY . .
WORKDIR "/src/src/WeLudic.PublicApi"
RUN dotnet build "WeLudic.PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeLudic.PublicApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeLudic.PublicApi.dll"]