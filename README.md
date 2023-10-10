# Assessments frontend

- Rødlista for arter 2021
- Fremmedartslista 2023
- Historiske data og visning av eldre lister

 Målet er å koble sammen så man også kan bla tilbake i tid for å se eldre visninger og lister.

## URL-er

| Url | .NET miljø | Branch
| :------------- | :------------- | :------------- |
| https://assessments-fe-dev.test.artsdatabanken.no | Staging | develop (default)
| https://assessments-fe.test.artsdatabanken.no | Staging | test
| https://assessments-fe.artsdatabanken.no | Production | master
| https://beta.artsdatabanken.no/lister/ | Staging | test
| https://artsdatabanken.no/lister/ | Production | master

https://beta.artsdatabanken.no/lister og  https://artsdatabanken.no/lister er tilgjengelig utenfor kontor eller uten vpn.

## Teknologi

- Prosjektet er en ASP-NET core web app (mvc)
- Data hentes og transformeres fra ulike databaser og lagres i Azure med prosjektet Assessments.Transformation (konsollapplikasjon)

Nyttig lenke om man er ny til teknologien: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio

## Oppsett

- Løsningen kjører i nyeste versjon av Visual Studio 
- Krever muligens noen installering før kjøring, trenger støtte for ASP.NET Core 6 
- Åpne assesment-frontend.sln og trykk kjør
- Datafiler hentes fra Azure storage og man MÅ ha en nøkkel for tilgang ("ConnectionStrings:AzureBlobStorage"), den må man få fra en av utviklerene på prosjektet - se https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
- Datafiler som brukes til datagrunnlag lages i konsollapplikasjonen Assessments.Transformation. Applikasjonen henter vurderinger og transformerer de til JSON som lagres på Azure storage. Prosjektet krever også nøkler for database tilgang. Man trenger vpn for å koble til databasene.

## Deployment og bygging til Linux og docker

Git workflows representerer tre forskjellige versjoner av kjørende kode.
- develop
- test
- master

- Develop er default branch og publiseres på https://assessments-fe-dev.test.artsdatabanken.no. Deploy gjøres i Slack på kanalen #ops med kommando: `deploy assessments-fe-dev`
- Test(staging) er ment som en mere stabil testversjon og publiseres på https://assessments-fe.test.artsdatabanken.no. Deploy gjøres i Slack på kanalen #ops med kommando: `deploy assessments-fe`
- Master publiseres til https://assessments-fe.artsdatabanken.no. Deploy gjøres i Slack på kanalen #crocotta med kommando: `deploy assessments-fe`

Det må lages pull request før merging til alle brancher

## Deployment og bygging til IIS/Windows (hjemmesiden)

- Test (beta): Bygger test ved å trykke "build now" for 'assessments-fe-test' i Jenkins.
- Main (prod): Bygger master ved å trykke "build now" for 'assessments-fe-drift' i Jenkins. 

### Deplyment til iis som website eller applikasjon under en website:

- Bygg løsningen
```cmd
rem Bygg og publish en release av nettsiden:
dotnet publish Assessments-frontend.sln -c Release

rem Kopier den ferdig bygde applikasjone 
robocopy "Assessments.Frontend.Web\bin\Release\net7.0\publish" ...destinasjon...
```
- Registrer Environmentvariabel ConnectionStrings:AzureBlobStorage f.eks. i IIS - Server - Configuration Editor - system.webServer/aspNetCore/environmentVariables - da som ASPNETCORE_ConnectionStrings__AzureBlobStorage
- Legg til website eller applikasjon under website som peker på denne katalogen og som har app-pool for 'No managed code' (.net core)

## Bygge ny cache for versjonene i IIS

Det er laget jobber i Jenkins som stopper application pools sletter gammel cache og starter opp application pool. På det viset kan man få bygget ny cache, uten å bygge løsningen på nytt. Disse jobbene heter `assessments-fe-drift-fix-cache` og `assessments-fe-test-fix-cache` i "assessments-fe"

## Videre dokumentasjon - se "les meg"-filene for hvert prosjekt

- [Assessments.Frontend.Web](https://github.com/Artsdatabanken/assessments-frontend/blob/develop/Assessments.Frontend.Web/README.md)
- [Assessments.Transformation](https://github.com/Artsdatabanken/assessments-frontend/blob/develop/Assessments.Transformation/README.md)
- Teamskanal: "Prosjekt - Visning av ekspertvurderinger"
