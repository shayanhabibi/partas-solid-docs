module Partas.Solid.Docs.examples.SpreadPage

open Fable.Core
open Partas.Solid

[<Erase>]
type MyCenteredButton() =
    interface RegularNode
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = "flex w-full justify-center") {
            button().spread props
        }
[<Erase>]
type MyCenteredButtonTwo() =
    interface RegularNode
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = "flex w-full justify-center") {
            div(class' = props.class') { "Div" }
            button().spread props
        }
[<Erase>]
type MyCenteredButtonThree() =
    interface RegularNode
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = "flex w-full justify-center") {
            div(class' = props.class') { "Div" }
            button(class' = props.class').spread props
        }

[<SolidComponent>]
let SpreadExampleOne () =
    MyCenteredButton(class' = "bg-primary hover:bg-background") { "Centered" }

[<SolidComponent>]
let SpreadExampleTwo () =
    MyCenteredButtonTwo(class' = "bg-primary hover:bg-background") { "Centered" }

[<SolidComponent>]
let SpreadExampleThree () =
    MyCenteredButtonThree(class' = "bg-primary hover:bg-background") { "Centered" }

[<SolidComponent>]
let SpreadExampleZero () =
    let myObj = {| ``class`` = "bg-primary" |}
    div().spread myObj { "Primary BG" }
