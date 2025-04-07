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