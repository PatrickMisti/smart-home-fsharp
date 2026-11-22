module Api.Persistence

open System
open Microsoft.Extensions.Configuration

/// Konfiguration für Akka.Persistence.Sql (Abschnitt "Persistence" in appsettings.json).
///
/// Provider sind LinqToDB-Providernamen, z.B.
///   "SQLite.MS"    -> SQLite über Microsoft.Data.Sqlite
///   "PostgreSQL"   -> PostgreSQL über Npgsql
[<CLIMutable>]
type PersistenceOptions =
    { Provider: string
      ConnectionString: string }

let sectionName = "Persistence"

let load (configuration: IConfiguration) : PersistenceOptions =
    match configuration.GetSection(sectionName).Get<PersistenceOptions>() with
    | NonNull options when
        not (String.IsNullOrWhiteSpace options.Provider)
        && not (String.IsNullOrWhiteSpace options.ConnectionString)
        ->
        options
    | _ ->
        failwith $"Konfigurationsabschnitt '%s{sectionName}' (Provider, ConnectionString) fehlt oder ist unvollständig."
