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
            Pages("Why Partas.Solid", [|
                Page("Introduction")
                Page("Motivation")
            |])
            Pages("Getting Started", [|
                Page("Installation")
                Page("Compiling")
                Page("Usage Overview", href = "overview")
            |])
            Pages("Guides", [|
                Page("SolidTypeComponent")
                Page("Spread")
                Page("Context Providers", href = "context_providers")
                Page("Polymorphism")
                Page("Special/Custom Builders", href = "special_builders")
            |])
            Pages("Issue Reporting", [|
                Page("Debugging")
                Page("Common Issues", href = "common_issues")
            |])
        |]
        // todo - if i set default open here then it correctly prevents tooltip, but then disables toggle
        SidebarProvider() {
            div(class' = "grid w-full max-w-full max-h-full grid-flow-row-dense") {
                NavBar(class' = "row-span-1 max-h-12 h-12 border-border border-1 shadow-xs bg-background")
                div(class' = "row-span-99 grid grid-flow-col-dense grid-rows-1 place-self-stretch") {
                    AppSidebar(
                        class' = "col-span-1 place-self-start bg-background border-border border-r-1",
                        pages = pages
                    )
                    div(class' = "col-span-10 place-self-stretch flex w-full max-h-[calc(100vh-(var(--spacing)*12))] justify-center overflow-y-scroll px-4") {
                        MdxStyler() {
                            props.children
                        }
                    }
                }
            
                
            }
        }