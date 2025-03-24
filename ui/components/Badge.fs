﻿namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
module badge =
    let variants =
        Lib.cva
            "inline-flex items-center rounded-md border px-2.5 py-0.5 text-xs font-semibold transition-colors focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2"
            {| variants =
                {| variant =
                    {| ``default`` = "border-transparent bg-primary text-primary-foreground"
                       secondary = "border-transparent bg-secondary text-secondary-foreground"
                       outline = "text-foreground"
                       success = "border-success-foreground bg-success text-success-foreground"
                       warning = "border-warning-foreground bg-warning text-warning-foreground"
                       error = "border-error-foreground bg-error text-error-foreground" |} |}
               defaultVariants = {| variant = "default" |} |}

    [<StringEnum(CaseRules.LowerAll)>]
    type variant =
        | Default
        | Secondary
        | Outline
        | Success
        | Warning
        | Error

[<Erase>]
type Badge() =
    inherit div()

    [<Erase>]
    member val variant: badge.variant = unbox null with get, set

    [<Erase>]
    member val round: bool = unbox null with get, set

    [<SolidTypeComponent>]
    member props.constructor =
        let round = if props.round then "rounded-full" else ""
        div(
            class' =
                Lib.cn
                    [| badge.variants ({| variant = props.variant |})
                       round
                       props.class' |]
        )
            .spread
            props

[<Erase>]
module badgeDelta =
    let variants =
        Lib.cva "" {|
        variants = {|
            variant = {|
                success="bg-success text-success-foreground hover:bg-success"
                warning="bg-warning text-warning-foreground hover:bg-warning"
                error="bg-error text-error-foreground hover:bg-error"
            |}
        |}             
    |}
    
    [<StringEnum>]
    type Type =
        | Increase
        | ModerateIncrease
        | Unchanged
        | ModerateDecrease
        | Decrease

open badgeDelta

[<Erase>]
type BadgeDelta() =
    inherit Badge()
    [<Erase>]
    member val deltaType: badgeDelta.Type = unbox null with get,set
    [<SolidTypeComponent>]
    member props.badgedelta =
        let typeClass =
            match props.deltaType with
            | ModerateIncrease
            | Increase -> badgeDelta.variants({| variant = "success" |})
            | Unchanged -> badgeDelta.variants({| variant = "warning" |})
            | ModerateDecrease
            | Decrease -> badgeDelta.variants( {| variant = "error" |} )
        let typeIcon iconClass: HtmlElement =
            match props.deltaType with
            | Increase -> Lucide.Lucide.ArrowUp(class'=iconClass)
            | ModerateIncrease -> Lucide.Lucide.ArrowUpRight(class'=iconClass)
            | Unchanged -> Lucide.Lucide.ArrowRight(class'=iconClass)
            | ModerateDecrease -> Lucide.Lucide.ArrowDownRight(class'=iconClass)
            | Decrease -> Lucide.Lucide.ArrowDown(class'=iconClass)
        let icon = typeIcon "size-4"
        
        Badge( class' = Lib.cn [|
            typeClass
            props.class'
        |]).spread(props) {
            span(class' = "flex gap-1") {
                icon
                props.children
            }
        }