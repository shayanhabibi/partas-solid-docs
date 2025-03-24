namespace Partas.Solid.Docs

open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Router
open Partas.Solid.UI
open Partas.Solid.Docs.Sidebar

[<Erase>]
type App() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let pages = [|
            Pages("Getting Started", [|
                Page("Introduction")
                Page("Installation")
                Page("Compiling")
                Page("Motivation")
            |])
        |]
        SidebarProvider() {
            div(class' = "flex flex-col w-full max-h-screen") {
                NavBar(class' = "sticky top-0 w-full h-12 border-border border-1 shadow-xs bg-background")
                div(class' = "flex flex-row grow") {
                    AppSidebar(
                        class' = "bg-background border-border border-1 border-t-0",
                        pages = pages
                    )
                    div(class' = "flex w-full max-h-[calc(100vh-(var(--spacing)*12))] justify-center overflow-y-scroll px-4") {
                        MdxStyler() {
                            props.children
                        }
                    }
                }
                
            }
        }