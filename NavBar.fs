﻿module Partas.Solid.Docs.NavBar

open Partas.Solid.Lucide
open Partas.Solid.Docs.Types
open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Partas.Solid.UI
open Partas.Solid.UI.Context
open Fable.Core
open Fable.Core.JsInterop
open Fable.Core.JS
open Partas.Solid.Primitives
open Partas.Solid.UI.Sidebar.Context

[<Erase>]
type NavBar() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let ctx = useSidebar()
        div(class' = Lib.cn [|
            "flex gap-8 pr-8 items-center justify-between"
            props.class'
        |]).spread(props) {
            div(class' = "flex flex-row gap-2 " + if Data.Window.isMobile() then "pl-2" else "pl-8" ) {
                if Data.Window.isMobile() then
                    SidebarTrigger(onClick = fun _ -> if ctx.openMobile() then ctx.setOpenMobile false else ctx.setOpenMobile true)
                span(class' = "flex text-2xl font-bold") {
                    AnimatedShinyText() { "Partas" }
                    ".Solid"
                }
                Badge(class' = "h-6 self-center text-[10px]", variant = Badge.Variant.Success) {
                    Lucide.PartyPopper(class' = "pr-2 self-center")
                    if Data.Window.isMobile() then
                        "1.0.0"
                    else
                        "v 1.0.0!"
                }
            }
            div() {
                NavigationMenu() {
                    if not <| Data.Window.isMobile() then
                        A(
                            class' =
                                "group/trigger inline-flex h-10 w-full items-center justify-center whitespace-nowrap
                                rounded-md bg-background px-4 py-2 text-sm font-medium transition-colors hover:bg-accent
                                hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground
                                focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-accent/50
                                data-[expanded]:bg-accent/50 bg-sidebar",
                            href = "https://github.com/shayanhabibi/partas-solid-docs"
                        ) { "Source" }
                    NavigationMenuItem() {
                        NavigationMenuTrigger(class' = "bg-sidebar") {
                            "Ecosystem" ; NavigationMenuIcon()
                        }
                        NavigationMenuContent(
                            class' = "grid w-[90vw] grid-rows-3 gap-3 sm:w-[500px] sm:grid-cols-2 md:w-[500px] lg:w-[500px] lg:grid-cols-[.75fr_1fr] [&>li:first-child]:row-span-3"
                        ) {
                            NavigationMenuLink(
                                href = "https://github.com/shayanhabibi/Partas.Solid.UI",
                                class' = "box-border flex size-full select-none flex-col justify-end rounded-md bg-gradient-to-b from-muted/50 to-muted p-6 no-underline focus:shadow-md"
                            ) {
                                GitGraph(class' = "size-6")
                                NavigationMenuLabel(class' = "mb-2 mt-4 text-lg font-medium") {
                                    "Partas.Solid.UI"
                                }
                                NavigationMenuDescription(class' = "text-sm leading-tight text-muted-foreground") {
                                    "Solid-ui rewritten with Partas.Solid.
                                    <br/><br/>Headless components beautifully styled with Tailwind CSS."
                                }
                            }
                            NavigationMenuLink(
                                href = "https://github.com/shayanhabibi/Partas.Solid.Bindings"
                            ) {
                                NavigationMenuLabel() { "Partas.Solid.Bindings" }
                                NavigationMenuDescription() {
                                    "Bindings for libraries in, or compatible with, Partas.Solid"
                                }
                            }
                            NavigationMenuLink(href = "https://github.com/shayanhabibi/Partas.Solid.Primitives") {
                                NavigationMenuLabel() { "Partas.Solid.Primitives" }
                                NavigationMenuDescription() {
                                    "Bindings for solid-primitives for Partas.Solid"
                                }
                            }
                        }
                    }
                }
            }
        }
