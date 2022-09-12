# "Assessments" frontend
- Rødlista for arter 2021
- Historiske data og visning av eldre rødlister
- Historiske visninger av fremmedartslistene

I første omgang samles alt av rødlister for arter i en løsning opp mot lansering av den nye rødlista for arter i 2021. Målet er å koble sammen så man også kan bla tilbake i tid for å se på eldre visninger og rødlister. Etterhvert vil rødlista for natur og fremmedartslistene også kobles inn i samme system. Det blir nok ikke i første omgang

## URL-er

Hjemmesider:
 - Test: https://assessments-fe.test.artsdatabanken.no
 - Produksjon: https://assessments-fe.artsdatabanken.no

API:
 - Test: https://assessments-fe.test.artsdatabanken.no/swagger/index.html
 - Produksjon: https://assessments-fe.artsdatabanken.no/swagger/index.html

Alle sites er beskyttet og krever VPN (man trenger ikke være koblet på for å kjøre prosjektet under utvikling lokalt). 

## Teknologi
- Prosjektet er en ASP-NET core web app (mvc)
- Data er hentet og transformert fra databasen i https://github.com/Artsdatabanken/Rodliste2019 

## Oppsett
- Løsningen kjører i nyeste versjon av visual studio 
- Krever muligens noen installering før kjøring, trenger støtte for ASP.NET Core 5.0 
- Åpne assesment-frontend.sln og trykk kjør
- Krever vpn.
- Datafiler hentes fra Azure storage og man MÅ ha en nøkkel for tilgang ("ConnectionStrings:AzureBlobStorage"), den må man få fra en av utviklerene på prosjektet (vi trenger helst annen løsning på sikt - muligens Azure key vault?) - se https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
- Datafiler som brukes til datagrunnlag lages i konsollapplikasjonen Assessments.Transformation. Applikasjonen henter vurderinger og transformerer de til en JSON fil som lagres på Azure storage. Prosjektet krever også nøkkel for database ("ConnectionStrings:Rodliste2020). Man trenger vpn for å bruke databasen.

Nyttig lenke om man er ny til teknologien: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio

## Deployment og bygging til Linux og docker
Git workflows representerer tre forskjellige versjoner av kjørende kode.
- develop
- test
- main/master

- Develop branch er fritt vilt og alle push(og eventuelle PR) til denne bygges og publiseres på: https://assessments-fe-dev.test.artsdatabanken.no. Egnet for kortlevde tester.
- Test(staging) er en mer stabil testversjon og vil kun bygge og publisere om en PR merges inn i branchen. Denne bygges da og publiseres på https://assessments-fe.test.artsdatabanken.no
- Main/master bygges ved push(for å kunne adhoc rette akutte feil i produksjon) og om en PR merges inn i branchen. Denne kan publiseres ved å gå til #crocotta og bruk kommandoen "deploy assessments-fe" - den havner da hit: https://assessments-fe.artsdatabanken.no 

## Deployment og bygging til IIS/Windows
- Test(beta): Bygger test ved å trykke "build now" for 'assessments-fe-test' i Jenkins.
- Main(prod): Bygger master/main ved å trykke "build now" for 'assessments-fe-drift' i Jenkins. 

### Deplyment til iis som website eller applikasjon under en website:

- Bygg løsningen
```cmd
rem Bygg og publish en release av nettsiden:
dotnet publish Assessments-frontend.sln -c Release

rem Kopier den ferdig bygde applikasjone 
robocopy "Assessments.Frontend.Web\bin\Release\net5.0\publish" ...destinasjon...
```
- Registrer Environmentvariabel ConnectionStrings:AzureBlobStorage f.eks. i IIS - Server - Configuration Editor - system.webServer/aspNetCore/environmentVariables - da som ASPNETCORE_ConnectionStrings__AzureBlobStorage
- Legg til website eller applikasjon under website som peker på denne katalogen og som har app-pool for 'No managed code' (.net core)


## Bygge ny cache for versjonene i IIS
Det er laget jobber i Jenkins som stopper application pools sletter gammel cache og starter opp application pool. På det viset kan man få bygget ny cache, uten å bygge løsningen på nytt. 
