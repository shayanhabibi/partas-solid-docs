namespace Partas.Solid.Docs

open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Partas.Solid.UI
open Partas.Solid.Lucide
open Fable.Core
open Fable.Core.JsInterop
open Fable.Core.JS

[<Erase>]
type NavBar() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = Lib.cn [|
            "flex gap-8 px-8 items-center justify-between"
            props.class'
        |]).spread(props) {
            div() {
                span(class' = "text-2xl font-bold") {
                    AnimatedShinyText() { "Partas" }
                    ".Solid"
                }
            }
            div() {
                NavigationMenu() {

                    A(
                        class' =
                            "group/trigger inline-flex h-10 w-full items-center justify-center whitespace-nowrap
                            rounded-md bg-background px-4 py-2 text-sm font-medium transition-colors hover:bg-accent
                            hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground
                            focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-accent/50
                            data-[expanded]:bg-accent/50",
                        href = ""
                    ) { "Docs" }
                    NavigationMenuItem() {
                        NavigationMenuTrigger() {
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
                        }
                    }
                }
            }
        }
