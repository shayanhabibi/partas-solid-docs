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
        Route(path = "", component' = IntroductionPage)
        Route(path = "introduction", component' = IntroductionPage)
        Route(path = "installation", component' = InstallationPage)
        Route(path = "compiling", component' = CompilingPage)
        Route(path = "motivation", component' = MotivationPage)
        Route(path = "overview", component' = OverviewPage)
        Route(path = "solidtypecomponent", component' = SolidTypeComponentPage)
        Route(path = "spread", component' = SpreadPage)
        Route(path = "context_providers", component' = ContextProvidersPage)
        Route(path = "polymorphism", component' = PolymorphismPage)
        Route(path = "special_builders", component' = SpecialBuildersPage)
        Route(path = "debugging", component' = DebuggingPage)
        Route(path = "common_issues", component' = CommonIssuesPage)
        Route(path = "plugin", component' = PluginPage)
    }

render(Root, document.getElementById "root")