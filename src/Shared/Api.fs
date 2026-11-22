namespace Shared

/// Ein Gerät im Smart Home.
type Device =
    { Id: string
      Name: string
      IsOnline: bool }

/// Routen-Schema für Fable.Remoting, von Server und Client gemeinsam genutzt.
module Route =
    /// Erzeugt z.B. /api/ISmartHomeApi/getDevices
    let builder (typeName: string) (methodName: string) = $"/api/%s{typeName}/%s{methodName}"

/// Der Remoting-Contract zwischen Api und UI.
type ISmartHomeApi =
    { getDevices: unit -> Async<Device list> }
