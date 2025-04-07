module Partas.Solid.Docs.examples.OverviewPage

open Partas.Solid
open Fable.Core

[<Erase>]
type ButtonVariant =
    | Primary
    | Ghost

[<SolidComponent>]
let Button (title: string) (variant: ButtonVariant) =
    button(class' = match variant with
                    | Primary -> "bg-primary text-primary-foreground"
                    | Ghost -> "bg-background") { title }

[<SolidComponent>]
let ButtonExample () =
    let variant, setVariant = createSignal(Ghost)
    div(class' = "flex justify-center w-full gap-x-2") {
        Button "Primary" Primary
        Button "Ghost" Ghost
        Button "Responsive" (variant())
        button(onClick = fun _ ->
            if variant() = Primary
            then Ghost
            else Primary
            |> setVariant) { "Click me" }
    }