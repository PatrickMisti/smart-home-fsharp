module UI.App

open Elmish
open Feliz
open Shared

// ---------- Model ----------

type RemoteData<'T> =
    | NotAsked
    | Loading
    | Loaded of 'T
    | Failed of string

type Model = { Devices: RemoteData<Device list> }

// ---------- Messages ----------

type Msg =
    | LoadDevices
    | DevicesLoaded of Device list
    | DevicesFailed of exn

// ---------- Init / Update ----------

let init () : Model * Cmd<Msg> = { Devices = NotAsked }, Cmd.ofMsg LoadDevices

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | LoadDevices ->
        { model with Devices = Loading },
        Cmd.OfAsync.either Api.smartHomeApi.getDevices () DevicesLoaded DevicesFailed
    | DevicesLoaded devices -> { model with Devices = Loaded devices }, Cmd.none
    | DevicesFailed ex -> { model with Devices = Failed ex.Message }, Cmd.none

// ---------- View ----------

let private deviceRow (device: Device) =
    let status = if device.IsOnline then "online" else "offline"

    Html.li [ prop.key device.Id; prop.text $"{device.Name} ({status})" ]

let view (model: Model) (dispatch: Msg -> unit) =
    Html.main [
        Html.h1 "Smart Home"
        Html.button [ prop.text "Neu laden"; prop.onClick (fun _ -> dispatch LoadDevices) ]
        match model.Devices with
        | NotAsked -> Html.none
        | Loading -> Html.p "Lade Geräte..."
        | Failed error -> Html.p [ prop.style [ style.color.red ]; prop.text error ]
        | Loaded [] -> Html.p "Keine Geräte gefunden."
        | Loaded devices -> Html.ul (devices |> List.map deviceRow)
    ]
