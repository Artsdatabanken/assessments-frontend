#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
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
ENTRYPOINT ["dotnet", "Assessments.Frontend.Web.dll"]