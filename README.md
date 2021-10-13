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

## Deployment
Deployment er delt i test og produksjon og skjer via github actions. Deployment til test skjer automatisk ved innsjekk av alle brancher som ikke er main/master. Ønsker du av en eller annen grunn å utelate din branch fra bygging/deployment til test, må du legge til denne i lista i fila: .github/workflows/test.yml under "branches ignore". 

Dockerimage bygges og sendes til artdatabankens dockerhub:https://hub.docker.com/repository/docker/artsdatabanken/assessments-fe - det er foreløpig to tags; test og latest - henholdsvis test/produksjon. 

For å dytte ut gjeldende versjon til produksjon, gå til #crocotta og bruk kommandoen deploy assessments-fe - da hentes image med tag "latest" fra dockerhub. 
