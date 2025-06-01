module Partas.Solid.Docs.LinkPopover

open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JS

[<Erase>]
type LinkCard() =
    interface RegularNode
    // [<Erase>] member val link: string = undefined with get,set
    [<Erase>] member val href: string = undefined with get,set
    [<Erase>] member val avatar: string = undefined with get,set
    [<Erase>] member val fallback: string = undefined with get,set
    [<Erase>] member val description: string = undefined with get,set
    [<Erase>] member val icon: TagValue = undefined with get,set
    [<Erase>] member val caption: string = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.icon <- unbox (fun () -> div())
        // span(class' = "not-prose") {
            
        HoverCard() {
            HoverCardTrigger().as'(a(href = props.href)) { props.children }
            HoverCardContent(class' = "w-80") {
                div(class' = "flex justify space-x-4 items-center") {
                    Avatar(class' = "mb-4") {
                        AvatarImage(src = props.avatar)
                        AvatarFallback() { props.fallback }
                    }
                    div(class' = "space-y-1") {
                        h4(class' = "text-sm-font-semibold") { props.children }
                        p(class' = "text-sm") { props.description }
                        div(class' = "flex items-center pt-2") {
                            props.icon % div(class' = "mr-2 size-4 opacity-70")
                            " "
                            span(class' = "text-xs text-muted-foreground") { props.caption }
                        }
                    }
                    
                }
            }
        }
    
        // }
