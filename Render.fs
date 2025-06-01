module Partas.Solid.Docs.Render

open Partas.Solid
open Partas.Solid.Docs.Root
open Browser.Dom
open Fable.Core
open Fable.Core.JsInterop

importAll "./index.css"


render(Root, document.getElementById "root")
