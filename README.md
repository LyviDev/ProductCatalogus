# ProductCatalogus – Umbraco CMS

Een kleine productcatalogus gebouwd met **Umbraco 18** op **ASP.NET Core**, om de belangrijkste onderdelen van Umbraco in de praktijk te leren.

## Wat zit erin

- **Document Types**: Home, ProductOverzicht en Product (prijs, voorraad, omschrijving, afbeelding), met structuurregels voor de content-tree
- **Models Builder** (SourceCodeAuto): strongly typed C#-models voor alle Document Types
- **Razor-templates**: master-layout, productoverzicht en productdetailpagina met voorraadstatus
- **Block List**: de homepage is opgebouwd uit blokken (HeroBlok, UitgelichtProductBlok), weergegeven met C# pattern matching
- **Notification handler**: businessregel die opslaan blokkeert bij negatieve voorraad (`ContentSavingNotification`, geregistreerd via een `IComposer`)
- **Delivery API**: headless toegang tot de content als JSON

## Lokaal draaien

```bash
dotnet run
```

De database (SQLite) zit niet in de repo. Bij de eerste start kun je een admin-account aanmaken via een unattended install in `appsettings.Development.json`.

Headless endpoint:
`/umbraco/delivery/api/v2/content?filter=contentType:product`

## Zie ook

[VoorraadWebshop](https://github.com/LyviDev/VoorraadWebshop): dezelfde producten- en voorraadlogica als ASP.NET Core Web API met EF Core.
