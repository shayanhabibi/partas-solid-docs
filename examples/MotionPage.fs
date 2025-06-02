module Partas.Solid.Docs.examples.MotionPage

open Partas.Solid
open Partas.Solid.Style
open Partas.Solid.Motion
open Partas.Solid.UI
open Fable.Core.JsInterop
open Fable.Core


[<SolidComponent>]
let WordRotateExample () =
    div(class' = "flex justify-center") {
        WordRotate(class' = "text-4xl font-bold",
                   words = [| "Word" ; "Rotate" |])
    }

[<SolidComponent>]
let KeyframeExample () =
    let inline percent value = $"{value}%%"
    Motion.div(
        animate = [
            MotionStyle.scale !^[|1;2;2;1;1|]
            MotionStyle.rotate !^[|0;0;180;180;0|]
            MotionStyle.borderRadius !^[|percent 0; percent 0; percent 50; percent 50; percent 0|]
        ],
        transition = [
            MotionTransition.duration 2
            MotionTransition.easing Easing.EaseInOut
            MotionTransition.offset [|0.;0.2;0.5;0.8;1|]
            MotionTransition.repeat JS.Infinity
            MotionTransition.endDelay 1.
        ],
        class' = "w-[100px] h-[100px] bg-primary"
        )
