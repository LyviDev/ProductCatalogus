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

De SQLite-database zit niet in de repo. Voeg bij de eerste start dit blok toe aan `appsettings.Development.json`, binnen `Umbraco` → `CMS`:

```json
"Unattended": {
  "InstallUnattended": true,
  "UnattendedUserName": "Admin",
  "UnattendedUserEmail": "admin@example.com",
  "UnattendedUserPassword": "VervangDitWachtwoord123!"
},
```

Start daarna de app:

```bash
dotnet run
```

Umbraco maakt de database en het admin-account automatisch aan. Log in via `/umbraco` en haal het `Unattended`-blok daarna weer weg.

> **Let op:** In Umbraco staan Document Types en content in de database, niet in de code. Na een verse clone is de site dus leeg. De code (models, templates, handler) staat wel in de repo. In een echt project los je dit op met een tool als uSync, die Document Types als bestanden in source control zet.

Headless endpoint:
`/umbraco/delivery/api/v2/content?filter=contentType:product`

## Zie ook

[VoorraadWebshop](https://github.com/LyviDev/VoorraadWebshop): dezelfde producten- en voorraadlogica als ASP.NET Core Web API met EF Core.
