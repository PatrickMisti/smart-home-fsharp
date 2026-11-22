module UI.Main

open Elmish
open Elmish.React
#if DEBUG
open Elmish.HMR
#endif

Program.mkProgram App.init App.update App.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "app"
|> Program.run
