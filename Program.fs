module Partas.Solid.Docs.Root

open Browser
open Partas.Solid
open Partas.Solid.Router
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Docs

importAll "./index.css"


[<SolidComponent>]
let Root () =
    HashRouter(root = !@App) {
        Route(path = "")
        Route(path = "introduction", component' = IntroductionPage)
        Route(path = "installation", component' = InstallationPage)
    }

render(Root, document.getElementById "root")