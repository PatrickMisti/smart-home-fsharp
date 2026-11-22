module Api.Program

open System
open Akka.Hosting
open Akka.Persistence.Sql.Hosting
open Fable.Remoting.Giraffe
open Fable.Remoting.Server
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Shared

let remotingHandler: HttpHandler =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue (SmartHomeApi.create ())
    |> Remoting.buildHttpHandler

let webApp: HttpHandler =
    choose [
        remotingHandler
        GET >=> route "/health" >=> text "ok"
        RequestErrors.NOT_FOUND "Not found"
    ]

let configureAkka (persistence: Persistence.PersistenceOptions) (akka: AkkaConfigurationBuilder) (_: IServiceProvider) =
    akka
        .ConfigureLoggers(fun loggers -> loggers.AddLoggerFactory() |> ignore)
        .WithSqlPersistence(
            connectionString = persistence.ConnectionString,
            providerName = persistence.Provider,
            autoInitialize = true
        )
    |> ignore

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    let persistence = Persistence.load builder.Configuration

    builder.Services.AddGiraffe() |> ignore
    builder.Services.AddAkka("smart-home", configureAkka persistence) |> ignore

    let app = builder.Build()
    app.UseGiraffe webApp
    app.Run()

    0
