#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Install System.Drawing native dependencies (required by ClosedXML)
RUN apt-get update && apt-get install -y libgdiplus
RUN apt-get install fonts-crosextra-carlito
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
ENV ASPNETCORE_URLS="http://+:3001"
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Assessments.Frontend.Web/Assessments.Frontend.Web.csproj", "Assessments.Frontend.Web/"]
RUN dotnet restore "Assessments.Frontend.Web/Assessments.Frontend.Web.csproj"
COPY . .
WORKDIR "/src/Assessments.Frontend.Web"
RUN dotnet build "Assessments.Frontend.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assessments.Frontend.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN groupadd -r --gid 1007 dockerrunner && useradd -r -g dockerrunner dockerrunner

RUN mkdir /app/Cache
RUN chown dockerrunner:dockerrunner /app/Cache

USER dockerrunner
EXPOSE 3001
ENTRYPOINT ["dotnet", "Assessments.Frontend.Web.dll"]
