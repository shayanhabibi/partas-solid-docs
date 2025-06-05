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
    | Introduction
    | Installation
    | OxpeckerFork
    | Overview
    | Spread
    | Polymorphism
    | Bindings
    | Experimental
    | ModularForms
    | Motion
    | Kobalte
    | Lucide
    | Cmdk
    | ApexCharts
    | TanStackTable
    | Primitives
    | NeoDrag
    | Storybook
    | CompiledOutput
    | SolidComponentAttribute
    | SolidTypeComponentAttribute
    | PartasImportAttribute
    | ComponentFlags
    | ApiDifferences
    | Troubleshooting
    | Contributing
    | Interfaces
    | StyleHelpers
    [<SolidComponent>]
    member this.createNavigationItem (?icon, ?version: string) =
        match this with
        | OxpeckerFork -> "Why Fork Oxpecker?"
        | Overview -> "Usage Overview"
        | CompiledOutput -> "Advantages of JSX Output"
        | ApiDifferences -> "Solid-JS API Differences"
        | ComponentFlags -> "Component Flags"
        | StyleHelpers -> "Style Helpers"
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
        | Introduction ->
            import def (pg + "Introduction" + ext)
        | Installation ->
            import def (pg + "Installation" + ext)
        | Overview ->
            import def "./pages/Overview.mdx"
        | Spread ->
            import def "./pages/Spread.mdx"
        | Polymorphism ->
            import def "./pages/Polymorphism.mdx"
        | Bindings ->
            import def "./pages/Bindings.mdx"
        | Experimental ->
            import def "./pages/Experimental.mdx"
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
        | OxpeckerFork ->
            import def "./pages/OxpeckerFork.mdx"
        | Storybook ->
            import def "./pages/Storybook.mdx"
        | CompiledOutput ->
            import def "./pages/CompiledOutput.mdx"
        | SolidComponentAttribute ->
            import def (pg + "SolidComponentAttribute" + ext)
        | SolidTypeComponentAttribute ->
            import def (pg + "SolidTypeComponentAttribute" + ext)
        | PartasImportAttribute ->
            import def (pg + "PartasImportAttribute" + ext)
        | ComponentFlags ->
            import def (pg + "ComponentFlags" + ext)
        | ApiDifferences ->
            import def (pg + "ApiDifferences" + ext)
        | Troubleshooting ->
            import def (pg + "Troubleshooting" + ext)
        | Contributing ->
            import def (pg + "Contributing" + ext)
        | Interfaces ->
            import def (pg + "Interfaces" + ext)
        | StyleHelpers ->
            import def (pg + "StyleHelpers" + ext)

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
        PageRoute Pages.Overview
        PageRoute Pages.Spread
        PageRoute Pages.Polymorphism
        PageRoute Pages.Bindings
        PageRoute Pages.Experimental
        PageRoute Pages.ModularForms
        PageRoute Pages.Motion
        PageRoute Pages.Kobalte
        PageRoute Pages.Lucide
        PageRoute Pages.Cmdk
        PageRoute Pages.ApexCharts
        PageRoute Pages.TanStackTable
        PageRoute Pages.Primitives
        PageRoute Pages.NeoDrag
        PageRoute Pages.OxpeckerFork
        PageRoute Pages.Storybook
        PageRoute Pages.CompiledOutput
        PageRoute Pages.SolidComponentAttribute
        PageRoute Pages.SolidTypeComponentAttribute
        PageRoute Pages.PartasImportAttribute
        PageRoute Pages.ComponentFlags
        PageRoute Pages.ApiDifferences
        PageRoute Pages.Troubleshooting
        PageRoute Pages.Contributing
        PageRoute Pages.Interfaces
        PageRoute Pages.StyleHelpers
    }

Data.Navigation.store.Update [|
    NavigationGroup.create "" None [|
        Pages.Introduction.createNavigationItem()
        Pages.Overview.createNavigationItem()
        Pages.OxpeckerFork.createNavigationItem()
        Pages.Installation.createNavigationItem()
        Pages.CompiledOutput.createNavigationItem()
        Pages.ApiDifferences.createNavigationItem()
    |]
    NavigationGroup.create "Guides" None [|
        Pages.SolidComponentAttribute.createNavigationItem()
        Pages.SolidTypeComponentAttribute.createNavigationItem()
        Pages.PartasImportAttribute.createNavigationItem()
        Pages.ComponentFlags.createNavigationItem()
        Pages.Spread.createNavigationItem()
        Pages.Interfaces.createNavigationItem()
        Pages.Polymorphism.createNavigationItem()
        Pages.StyleHelpers.createNavigationItem()
        Pages.Experimental.createNavigationItem()
    |]
    NavigationGroup.create "Issue Reporting" None [|
        Pages.Troubleshooting.createNavigationItem()
    |]
    NavigationGroup.create "Dev/Contributing" None [|
        Pages.Bindings.createNavigationItem()
        Pages.Contributing.createNavigationItem()
    |]
    NavigationGroup.create "Bindings" None [|
        Pages.Primitives.createNavigationItem()
        Pages.Motion.createNavigationItem(version = "0.2.1")
        Pages.Kobalte.createNavigationItem(version = "0.2.0")
        Pages.ApexCharts.createNavigationItem(version = "0.2.0")
        Pages.Cmdk.createNavigationItem(version = "0.2.0")
        Pages.Lucide.createNavigationItem(version = "0.514.0")
        Pages.ModularForms.createNavigationItem(version = "0.2.0")
        Pages.NeoDrag.createNavigationItem(version = "0.2.0")
        Pages.TanStackTable.createNavigationItem(version = "0.2.0")
        Pages.Storybook.createNavigationItem(version = "0.1.2")
    |]
|]

