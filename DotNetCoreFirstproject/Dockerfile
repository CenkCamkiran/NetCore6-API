#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 #HTTP
EXPOSE 443 #HTTPS

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotNetCoreFirstproject/DotNetCoreFirstproject.csproj", "DotNetCoreFirstproject/"]
RUN dotnet restore "DotNetCoreFirstproject/DotNetCoreFirstproject.csproj"
COPY . .
WORKDIR "/src/DotNetCoreFirstproject"
RUN dotnet build "DotNetCoreFirstproject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetCoreFirstproject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetCoreFirstproject.dll"]