module UI.Api

open Fable.Remoting.Client
open Shared

/// Typisierter Proxy auf das Backend (Fable.Remoting).
let smartHomeApi: ISmartHomeApi =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<ISmartHomeApi>
