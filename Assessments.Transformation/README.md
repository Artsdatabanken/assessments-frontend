## Assessments.Transformation

Konsollapplikasjon som henter ekspertvurderinger fra ulike databaser, transformerer til datamodeller og lagrer som JSON-filer lokalt og i en Azure storage account.

## Connectionstrings

Brukes for tilgang til Azure storage account og databaser.
Legges til som [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows) i prosjektet. 

Oversikt over nøkler:

- Azure storage account: "ConnectionStrings:AzureBlobStorage" 
- Database for Rødlista 2021: "ConnectionStrings:Rodliste2020"
- Database for Fremmedartslista 2023: "ConnectionStrings:Fab4"