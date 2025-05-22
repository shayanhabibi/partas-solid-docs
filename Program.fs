module Partas.Solid.Docs.Root

open Browser
open Partas.Solid
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

importAll "./index.css"

[<RequireQualifiedAccess>]
type Pages =
    | Introduction
    | Installation
    | Compiling
    | Motivation
    | Overview
    | SolidTypeComponent
    | Spread
    | ContextProviders
    | Polymorphism
    | SpecialBuilders
    | Debugging
    | CommonIssues
    | Plugin
    | Setters
    | Bindings
    | Experimental
    | BuilderInterfaces
    member this.createNavigationItem icon =
        match this with
        | ContextProviders -> "Context Providers"
        | Overview -> "Usage Overview"
        | SpecialBuilders -> "Custom Builders"
        | CommonIssues -> "Common Issues"
        | BuilderInterfaces -> "Prebuilt Builder Interfaces"
        | _ -> this.ToString()
        |> NavigationItem.create
            <| this.ToString().ToLowerInvariant()
            <| icon
    member this.route: string * TagValue =
        this.ToString().ToLowerInvariant(),
        match this with
        | Compiling ->
            import "default as Compiling" "./pages/Compiling.mdx"
        | Introduction ->
            import "default as Introduction" "./pages/Introduction.mdx"
        | Installation ->
            import "default as Installation" "./pages/Installation.mdx"
        | Motivation ->
            import "default as Motivation" "./pages/Motivation.mdx"
        | Overview ->
            import "default as OverviewPage" "./pages/Overview.mdx"
        | SolidTypeComponent ->
            import "default as SolidTypeComponentPage" "./pages/SolidTypeComponent.mdx"
        | Spread ->
            import "default as SpreadPage" "./pages/Spread.mdx"
        | ContextProviders ->
            import "default as ContextProvidersPage" "./pages/ContextProviders.mdx"
        | Polymorphism ->
            import "default as PolymorphismPage" "./pages/Polymorphism.mdx"
        | SpecialBuilders ->
            import "default as SpecialBuildersPage" "./pages/SpecialBuilders.mdx"
        | Debugging ->
            import "default as DebuggingPage" "./pages/Debugging.mdx"
        | CommonIssues ->
            import "default as CommonIssuesPage" "./pages/CommonIssues.mdx"
        | Plugin ->
            import "default as PluginPage" "./pages/Plugin.mdx"
        | Setters ->
            import "default as SettersPage" "./pages/Setters.mdx"
        | Bindings ->
            import "default as BindingsPage" "./pages/Bindings.mdx"
        | Experimental ->
            import "default as ExperimentalPage" "./pages/Experimental.mdx"
        | BuilderInterfaces ->
            import "default as BuilderInterfacesPage" "./pages/BuilderInterfaces.mdx"

[<SolidComponent>]
let GithubVisit () =
    SidebarFooter() {
        SidebarMenu() {
            SidebarMenuItem(class' = "flex gap-2 items-center") {
                Motion(
                    hover = jsOptions<MotionStyle>(fun o -> o.scale <- unbox 1.10)
                )  {
                    Button(variant = button.variant.ghost, size = button.size.icon) {
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
    inherit RegularNode()
    [<SolidTypeComponent>]
    member props.__ =
        SidebarProvider().style'({| ``--navbar-size`` = NavigationBar.size |}) {
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
let Root () =
    HashRouter(root = !@RootApp) {
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
    }

Data.Navigation.store.Update [|
    NavigationGroup.create "" None [|
        Pages.Introduction.createNavigationItem None
        Pages.Compiling.createNavigationItem None
        Pages.Overview.createNavigationItem None
    |]
    NavigationGroup.create "Guides" None [|
        Pages.SolidTypeComponent.createNavigationItem None
        Pages.Spread.createNavigationItem None
        Pages.ContextProviders.createNavigationItem None
        Pages.Polymorphism.createNavigationItem None
        Pages.SpecialBuilders.createNavigationItem None
        Pages.BuilderInterfaces.createNavigationItem None
        Pages.Setters.createNavigationItem None
        Pages.Experimental.createNavigationItem None
    |]
    NavigationGroup.create "Issue Reporting" None [|
        Pages.Debugging.createNavigationItem None
        Pages.CommonIssues.createNavigationItem None
    |]
    NavigationGroup.create "Dev/Contributing" None [|
        Pages.Plugin.createNavigationItem None
        Pages.Bindings.createNavigationItem None
    |]
|]
render(Root, document.getElementById "root")
