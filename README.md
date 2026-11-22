# smart-home-fsharp
Actor-based smart home automation: Zigbee2MQTT, Akka.NET rule engine and SAFE Stack dashboard in F#

## Struktur

| Projekt | Inhalt |
|---|---|
| `src/Shared` | Gemeinsame Typen + Fable.Remoting-Contract (`ISmartHomeApi`) |
| `src/Api` | ASP.NET Core + Giraffe, Fable.Remoting, Akka.NET (Persistence.Sql), MQTTnet |
| `src/UI` | Fable + Elmish + Feliz, gebündelt mit Vite |
| `tests/Api.Tests` | xunit v3 |

Paketversionen werden zentral in `Directory.Packages.props` gepflegt, gemeinsame Build-Einstellungen in `Directory.Build.props`.

## Entwicklung

```sh
# Backend (http://localhost:5111)
dotnet run --project src/Api

# Frontend (http://localhost:8080, /api wird ans Backend weitergeleitet)
cd src/UI
npm install
npm run dev

# Tests
dotnet test --solution SmartHome.slnx
```

## Persistenz

Akka.Persistence.Sql wird über den Abschnitt `Persistence` in `src/Api/appsettings.json` konfiguriert.
Standard ist SQLite (`smarthome.db`); für PostgreSQL `Provider` auf `PostgreSQL` und den
`ConnectionString` entsprechend setzen. Tabellen werden automatisch angelegt.
