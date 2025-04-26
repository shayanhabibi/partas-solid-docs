module Partas.Solid.Docs.NavigationShell

open Browser.Types
open Fable.Core.JsInterop
open Partas.Solid.Docs.Types
open Partas.Solid.Docs.MdxStyler
open Partas.Solid.Docs.NavBar
open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Partas.Solid.UI
open Fable.Core
open Partas.Solid.UI.Context
open Partas.Solid.Motion
open Partas.Solid.Lucide

[<Erase>]
type NavigationBar() =
    inherit RegularNode()
    static member inline size: string = $"calc(var(--spacing)*{12}"
    [<DefaultValue>] val mutable items: NavigationItem[]
    [<SolidTypeComponent>]
    member props.__ =
        Fragment() {
            // Header
            div(class' = "fixed inset-x-0 top-0 z-10 border-b border-border") {
                // div(class' = "bg-sidebar flex h-(--navbar-size) items-center justify-between gap-8 px-4 sm:px-6") {
                //     SidebarTrigger()
                // }
            NavBar(class' = "h-(--navbar-size) bg-sidebar")
            }
            props.children
        }

[<Erase>]
type NavigationShell() =
    inherit RegularNode()
    [<DefaultValue>] val mutable header: HtmlElement
    [<DefaultValue>] val mutable sidebar: HtmlElement
    [<SolidTypeComponent>]
    member props.__ =
        Fragment() {
            props.header
            div(class' = " grid min-h-dvh pt-(--navbar-size)
                min-w-full max-w-min
                grid-cols-0 grid-rows-[1fr_1px_auto_1px_auto]
                lg:grid-cols-[var(--sidebar-width)_2.5rem_minmax(0,1fr)_2.5rem]
                xl:grid-cols-[var(--sidebar-width)_2.5rem_minmax(0,1fr)_2.5rem]
                has-data-[collapsible=icon]:lg:grid-cols-[var(--sidebar-width-icon)_3rem_minmax(0,1fr)_3rem]
                has-data-[collapsible=icon]:xl:grid-cols-[var(--sidebar-width-icon)_3rem_minmax(0,1fr)_3rem]
                duration-200 transition-[grid] ease-linear") {
                props.sidebar
                props.children
            }
        }

[<Erase>]
type NavSidebarContent() =
    inherit RegularNode()
    [<SolidTypeComponent>]
    member props.__ =
        let ctx = useSidebar()
        For(each = Data.Navigation.data) { yield fun group index ->
            SidebarGroup() {
                SidebarGroupLabel() {
                    group.Title
                }
                SidebarGroupContent() {
                    SidebarMenu() {
                        For(each = group.Items) { yield fun item itemIndex ->
                            SidebarMenuItem() {
                                SidebarMenuButton(
                                    tooltip = item.Title,
                                    class' = "group/mbutton disabled:cursor-default",
                                    onClick = fun _ -> if Data.Window.isMobile() && ctx.openMobile() then ctx.setOpenMobile(false)
                                    )
                                    .as' (
                                        A(href = item.Path)
                                    )
                                    {
                                        if item.Icon.IsSome
                                        then (unbox<TagValue> item.Icon) % {||}
                                        else
                                            Separator(
                                                orientation = Orientation.Vertical,
                                                class' = "group-hover/mbutton:bg-black/20 in-aria-[current=page]:bg-black transition-colors group-hover/mbutton:in-aria-[current=page]:bg-black"
                                                )
                                        span() { item.Title }
                                    }
                            }
                        }
                    }
                }
            }
        }

open Partas.Solid.Experimental

[<Erase>]
type SidebarShell() =
    inherit RegularNode()
    [<DefaultValue>] val mutable header: HtmlElement
    [<DefaultValue>] val mutable footer: HtmlElement
    [<SolidTypeComponent>]
    member props.__ =
        let ctx = useSidebar()
        
        let collapsible = fun () -> if Data.Window.isMobile() then sidebar.Collapsible.OffCanvas else sidebar.Collapsible.None
        
        div(id = "sidebar-container", class' = "relative col-start-1 row-span-full row-start-1 max-lg:hidden") {
            div(class' = $"absolute inset-0") {
                div(class' = "sticky top-(--navbar-size) bottom-0 left-0 h-full max-h-[calc(100dvh-(var(--navbar-size)))] overflow-y-hidden")
                    {
                        Sidebar(
                                collapsible = collapsible(),
                                class' = "top-(--navbar-size) max-h-[calc(100dvh-(var(--navbar-size)))]") {
                            SidebarHeader() {
                                if Data.Window.isMobile() then SidebarMenuAction(onClick = fun _ -> ctx.setOpenMobile false) { X() }
                                props.header
                            }
                            UI.SidebarContent() { NavSidebarContent() }
                            SidebarFooter() { props.footer }
                        }
                    }
            }
        }
        
[<Erase>]
type MainViewPort() =
    inherit RegularNode()
    [<SolidTypeComponent>]
    member props.__ =
        Fragment() {
            div(class' = "col-start-2 row-span-5 row-start-1")
            div(class' = "relative row-start-1 grid grid-cols-subgrid col-start-3") {
                div().bool("hidden", true)
                div(
                    class' = "mx-auto grid w-full grid-cols-1 gap-10 xl:grid-cols-[minmax(0,1fr)]") {
                    div(class' = "px-4 pt-10 pb-24 sm:px-6 xl:pr-0") {
                        MdxStyler() {
                            props.children
                        }
                    }
                }
            }
            div(class' = "col-start-5 row-span-5 row-start-1")
        }
