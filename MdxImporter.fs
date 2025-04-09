[<AutoOpen>]
module Partas.Solid.Docs.MdxImporter

open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid

let IntroductionPage: TagValue = import "default as Introduction" "./pages/Introduction.mdx"
let InstallationPage: TagValue = import "default as Installation" "./pages/Installation.mdx"
let CompilingPage: TagValue = import "default as Compiling" "./pages/Compiling.mdx"
let MotivationPage: TagValue = import "default as Motivation" "./pages/Motivation.mdx"
let OverviewPage: TagValue = import "default as OverviewPage" "./pages/Overview.mdx"
let SolidTypeComponentPage: TagValue = import "default as SolidTypeComponentPage" "./pages/SolidTypeComponent.mdx"
let SpreadPage: TagValue = import "default as SpreadPage" "./pages/Spread.mdx"
let ContextProvidersPage: TagValue = import "default as ContextProvidersPage" "./pages/ContextProviders.mdx"
let PolymorphismPage: TagValue = import "default as PolymorphismPage" "./pages/Polymorphism.mdx"
let SpecialBuildersPage: TagValue = import "default as SpecialBuildersPage" "./pages/SpecialBuilders.mdx"
let DebuggingPage: TagValue = import "default as DebuggingPage" "./pages/Debugging.mdx"
let CommonIssuesPage: TagValue = import "default as CommonIssuesPage" "./pages/CommonIssues.mdx"