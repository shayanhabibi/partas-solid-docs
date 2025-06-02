module Partas.Solid.Docs.Root

open Browser
open Partas.Solid
open Partas.Solid.Experimental
open Partas.Solid.Lucide
open Partas.Solid.Motion
open Partas.Solid.Motion.LibDom
open Partas.Solid.Router
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Docs
open Partas.Solid.Docs.NavigationShell
open Partas.Solid.Docs.Types
open Partas.Solid.UI

let [<Literal>] def = "default"
let [<Literal>] pg = "./pages/"
let [<Literal>] ext = ".mdx"

[<RequireQualifiedAccess>]
type Pages =
    | Introduction | Installation
    | Compiling | Motivation
    | Overview | SolidTypeComponent
    | Spread | ContextProviders
    | Polymorphism | SpecialBuilders
    | Debugging | CommonIssues
    | Plugin | Setters | Bindings
    | Experimental | BuilderInterfaces
    | Components | Terminology
    | ModularForms | Motion
    | Kobalte | Lucide | Cmdk
    | ApexCharts | TanStackTable
    | Primitives | NeoDrag
    [<SolidComponent>]
    member this.createNavigationItem (?icon, ?version: string) =
        match this with
        | ContextProviders -> "Context Providers"
        | Overview -> "Usage Overview"
        | SpecialBuilders -> "Custom Builders"
        | CommonIssues -> "Common Issues"
        | BuilderInterfaces -> "Prebuilt Builder Interfaces"
        | _ -> this.ToString()
        |> NavigationItem.create
            <| this.ToString().ToLowerInvariant()
            <|
                if version.IsSome then
                    let comp () =
                        Badge(variant = Badge.Variant.Secondary) {version.Value}
                    Some !!comp
                else icon
    member this.route: string * TagValue =
        this.ToString().ToLowerInvariant(),
        match this with
        | Compiling ->
            import def (pg + "Compiling" + ext)
        | Introduction ->
            import def (pg + "Introduction" + ext)
        | Installation ->
            import def (pg + "Installation" + ext)
        | Motivation ->
            import def "./pages/Motivation.mdx"
        | Overview ->
            import def "./pages/Overview.mdx"
        | SolidTypeComponent ->
            import def "./pages/SolidTypeComponent.mdx"
        | Spread ->
            import def "./pages/Spread.mdx"
        | ContextProviders ->
            import def "./pages/ContextProviders.mdx"
        | Polymorphism ->
            import def "./pages/Polymorphism.mdx"
        | SpecialBuilders ->
            import def "./pages/SpecialBuilders.mdx"
        | Debugging ->
            import def "./pages/Debugging.mdx"
        | CommonIssues ->
            import def "./pages/CommonIssues.mdx"
        | Plugin ->
            import def "./pages/Plugin.mdx"
        | Setters ->
            import def "./pages/Setters.mdx"
        | Bindings ->
            import def "./pages/Bindings.mdx"
        | Experimental ->
            import def "./pages/Experimental.mdx"
        | BuilderInterfaces ->
            import def "./pages/BuilderInterfaces.mdx"
        | Components ->
            import def "./pages/Components.mdx"
        | Terminology ->
            import def "./pages/Terminology.mdx"
        | ModularForms ->
            import def "./pages/ModularForms.mdx"
        | Motion ->
            import def "./pages/Motion.mdx"
        | Kobalte ->
            import def "./pages/Kobalte.mdx"
        | Lucide ->
            import def "./pages/Lucide.mdx"
        | Cmdk ->
            import def "./pages/Cmdk.mdx"
        | ApexCharts ->
            import def "./pages/ApexCharts.mdx"
        | TanStackTable ->
            import def "./pages/TanStackTable.mdx"
        | Primitives ->
            import def "./pages/Primitives.mdx"
        | NeoDrag ->
            import def "./pages/NeoDrag.mdx"

[<SolidComponent>]
let GithubVisit () =
    SidebarFooter() {
        SidebarMenu() {
            SidebarMenuItem(class' = "flex gap-2 items-center") {
                Motion(
                    hover = [
                        MotionStyle.scale 1.1
                    ]
                )  {
                    Button(variant = Button.Variant.Ghost, size = Button.Size.Icon)
                        .as' (A(href = "https://github.com/shayanhabibi/Partas.Solid")) {
                        Lucide.Github()
                    }
                }
                div(class' = "flex flex-col content-between") {
                    Label() { "Lovingly Open Source" }
                    Label(class' = "font-normal") { "Leave a star!" }
                }
            }
        }
    }

[<Erase>]
type RootApp() =
    interface RegularNode
    [<SolidTypeComponent>]
    member props.__ =
        SidebarProvider(mobileBreakpoint = 1023).style' [ "--navbar-size" ==> NavigationBar.size ] {
            NavigationShell(
                header = NavigationBar(),
                sidebar = SidebarShell(footer = GithubVisit())
            ) {
                MainViewPort() {
                    props.children
                }
            }
        }

[<SolidComponent>]
let PageRoute (page: Pages) =
    let path,pageComponent = page.route
    Route(path = path, component' = pageComponent)

[<SolidComponent>]
let LandingPage () =
    // nothing for landing page, route directly to introduction
    let navigate = useNavigate()
    mount {
        navigate.InvokeOptions("introduction", replace = true)
    }

[<SolidComponent>]
let Root () =
    HashRouter(root = !@RootApp) {
        // This will only route to introduction if we land at the
        // index page
        Route(path = "/", component' = !!LandingPage)
        PageRoute Pages.Introduction
        PageRoute Pages.Installation
        PageRoute Pages.Compiling
        PageRoute Pages.Motivation
        PageRoute Pages.Overview
        PageRoute Pages.SolidTypeComponent
        PageRoute Pages.Spread
        PageRoute Pages.ContextProviders
        PageRoute Pages.Polymorphism
        PageRoute Pages.SpecialBuilders
        PageRoute Pages.Debugging
        PageRoute Pages.CommonIssues
        PageRoute Pages.Plugin
        PageRoute Pages.Setters
        PageRoute Pages.Bindings
        PageRoute Pages.Experimental
        PageRoute Pages.BuilderInterfaces
        PageRoute Pages.Components
        PageRoute Pages.Terminology
        PageRoute Pages.ModularForms
        PageRoute Pages.Motion
        PageRoute Pages.Kobalte
        PageRoute Pages.Lucide
        PageRoute Pages.Cmdk
        PageRoute Pages.ApexCharts
        PageRoute Pages.TanStackTable
        PageRoute Pages.Primitives
        PageRoute Pages.NeoDrag
    }

Data.Navigation.store.Update [|
    NavigationGroup.create "Finished Pages" None [|
        Pages.Introduction.createNavigationItem()
        Pages.Motion.createNavigationItem(version = "0.2.1")
        Pages.Kobalte.createNavigationItem(version = "0.2.0")        
    |]
    NavigationGroup.create "" None [|
        Pages.Introduction.createNavigationItem()
        Pages.Installation.createNavigationItem()
        Pages.Compiling.createNavigationItem()
        Pages.Overview.createNavigationItem()
    |]
    NavigationGroup.create "Guides" None [|
        Pages.SolidTypeComponent.createNavigationItem()
        Pages.Spread.createNavigationItem()
        Pages.ContextProviders.createNavigationItem()
        Pages.Polymorphism.createNavigationItem()
        Pages.SpecialBuilders.createNavigationItem()
        Pages.BuilderInterfaces.createNavigationItem()
        Pages.Setters.createNavigationItem()
        Pages.Experimental.createNavigationItem()
        Pages.Components.createNavigationItem()
    |]
    NavigationGroup.create "Issue Reporting" None [|
        Pages.Debugging.createNavigationItem()
        Pages.CommonIssues.createNavigationItem()
    |]
    NavigationGroup.create "Dev/Contributing" None [|
        Pages.Plugin.createNavigationItem()
        Pages.Bindings.createNavigationItem()
    |]
    NavigationGroup.create "Bindings" None [|
        Pages.Primitives.createNavigationItem()
        Pages.Motion.createNavigationItem(version = "0.2.1")
        Pages.Kobalte.createNavigationItem(version = "0.2.0")
        Pages.ApexCharts.createNavigationItem(version = "0.2.0")
        Pages.Cmdk.createNavigationItem(version = "0.2.0")
        Pages.Lucide.createNavigationItem(version = "0.2.0")
        Pages.ModularForms.createNavigationItem(version = "0.2.0")
        Pages.NeoDrag.createNavigationItem(version = "0.2.0")
        Pages.TanStackTable.createNavigationItem(version = "0.2.0")
    |]
|]

