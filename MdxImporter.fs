[<AutoOpen>]
module Partas.Solid.Docs.MdxImporter

open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid

let IntroductionPage: TagValue = import "default as Introduction" "./pages/Introduction.mdx"
let InstallationPage: TagValue = import "default as Installation" "./pages/Installation.mdx" 