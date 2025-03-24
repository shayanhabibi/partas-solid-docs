﻿namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Motion
open Fable.Core.JsInterop
open Fable.Core.JS
open Fable.Core
open System

[<Pojo>]
type FlipTextStates(?initial: MotionStyle, ?animate: MotionStyle) =
    member val initial = initial |> Option.defaultValue null with get,set
    member val animate = animate |> Option.defaultValue null with get,set

[<Erase>]
type FlipText() =
    inherit VoidNode()
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val duration: float = unbox null with get,set
    [<Erase>] member val delayMultiple: float = unbox null with get,set
    [<Erase>] member val states: FlipTextStates = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.duration <- 0.5
        props.delayMultiple <- 0.08
        props.states <- FlipTextStates(
                initial = jsOptions<MotionStyle>(fun o ->
                    o.rotateX <- !!(-90)
                    o.opacity <- !!0),
                animate = jsOptions<MotionStyle>(fun o ->
                    o.rotateX <- !!0
                    o.opacity <- !!1)
            )
        div(class' = Lib.cn [| "flex"; props.class' |]) {
            For(each = (props.text |> _.ToCharArray() |> Array.map string )) {
                yield fun letter index ->
                    Motion(
                        initial = props.states.initial,
                        inView = props.states.animate,
                        transition = jsOptions<AnimationOptions>(fun o ->
                            o.duration <- !!props.duration
                            o.delay <- !!(!!index() * props.delayMultiple) )
                    ) {
                        if letter = " " then "\u00a0"
                        else letter
                    }
            }
        }
