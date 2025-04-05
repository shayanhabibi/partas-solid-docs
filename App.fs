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
            div(class' = "grid w-full max-h-full grid-flow-row-dense") {
                NavBar(class' = "max-h-12 border-border border-1 shadow-xs bg-background")
                div(class' = "grid grid-flow-col-dense grid-rows-1") {
                    AppSidebar(
                        class' = "col-span-1 place-self-start bg-background border-border border-r-1",
                        pages = pages
                    )
                    div(class' = "col-span-10 place-self-stretch flex w-full max-h-[calc(100vh-(var(--spacing)*12))] justify-center overflow-y-scroll px-4") {
                        MdxStyler() {
                            props.children
                        }
                    }
                    div(class' = "col-span-1")
                }
            
                
            }
        }