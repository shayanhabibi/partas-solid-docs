module Partas.Solid.Docs.examples.SpecialBuildersPage

open Partas.Solid
open Fable.Core

[<SolidComponent>]
let ForExample () =
    For(each = [| "button1" ; "button2" |]) {
        yield fun item index ->
            button() { item }
    }