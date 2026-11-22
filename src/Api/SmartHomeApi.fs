module Api.SmartHomeApi

open Shared

/// Server-Implementierung des Remoting-Contracts aus Shared.
/// Vorerst statische Daten – später kommen die Geräte aus den Akka-Aktoren.
let create () : ISmartHomeApi =
    { getDevices =
        fun () ->
            async {
                return
                    [ { Id = "lamp-1"; Name = "Wohnzimmer Lampe"; IsOnline = true }
                      { Id = "sensor-1"; Name = "Temperatursensor Bad"; IsOnline = false } ]
            } }
