# "Assessments" frontend
- Rødlista for arter 2021
- Historiske data og visning av eldre rødlister
- Historiske visninger av fremmedartslistene

I første omgang samles alt av rødlister for arter i en løsning opp mot lansering av den nye rødlista for arter i 2021. Målet er å koble sammen så man også kan bla tilbake i tid for å se på eldre visninger og rødlister. Etterhvert vil rødlista for natur og fremmedartslistene også kobles inn i samme system. Det blir nok ikke i første omgang

## Teknologi
- Prosjektet er en ASP-NET core web app (mvc)
- Datane hentes via et api som ligger her: https://github.com/Artsdatabanken/assessments-api

## Oppsett
- Løsningen kjører i nyeste versjon av visual studio 
- Krever muligens noen installering før kjøring, trenger støtte for ASP.NET Core 5.0 
- Åpne assesment-frontend.sln og trykk kjør
- Krever ikke vpn.

Nyttig lenke om man er ny til teknologien: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio
