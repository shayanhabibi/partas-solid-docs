﻿module Partas.Solid.Docs.Sidebar

open Fable.Core
open Partas.Solid.Kobalte
open Partas.Solid.Lucide
open Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Partas.Solid.Motion

[<JS.Pojo>]
type Page(
        title: string,
        ?href: string,
        ?icon: TagValue
    ) =
    member val title = title with get,set
    member val href = href with get,set
    member val icon = icon with get,set

[<JS.Pojo>]
type Pages(
        title: string,
        pages: Page[]
    ) =
    member val title = title with get,set
    member val pages = pages with get,set
[<Erase>]
type PageItem() =
    inherit RegularNode()
    [<Erase>] member val title: string = unbox null with get,set
    [<Erase>] member val href : string option = unbox null with get,set
    [<Erase>] member val icon : TagValue option = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =        
        let href = createMemo(fun () ->
            props.href |> Option.defaultValue props.title |> _.ToLowerInvariant())
        SidebarMenuItem() {
            SidebarMenuButton(tooltip = props.title, class' = "group/mbutton").as'(A(href = href())) {
                if unbox props.icon then
                    (unbox<TagValue> props.icon) % {| class' = "size-4" |}
                Separator(orientation = Orientation.Vertical, class' = "group-hover/mbutton:bg-black/20 in-aria-[current=page]:bg-black transition-colors group-hover/mbutton:in-aria-[current=page]:bg-black")
                span() { props.title }
            }
        }

[<Erase>]
type PageGroup() =
    inherit RegularNode()
    [<Erase>] member val title: string = unbox null with get,set
    [<Erase>] member val pages: Page[] = unbox null with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        SidebarGroup() {
            SidebarGroupLabel() { props.title }
            SidebarGroupContent() {
                SidebarMenu() {
                    For(each = props.pages) {
                        yield fun page index ->
                            PageItem().spread page
                    }
                }
            }
        }

[<Erase>]
type AppSidebar() =
    inherit Sidebar()
    [<Erase>] member val pages: Pages[] = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.collapsible <- sidebar.Collapsible.None
        props.variant <- sidebar.Variant.Inset
        props.pages <- [||]
        
        Sidebar(
            collapsible = props.collapsible,
            variant = props.variant
        ).spread(props) {
            
            SidebarHeader() {
                // SidebarInput()
            }
            
            SidebarContent(
            ) {
                For(each = props.pages) {
                    yield fun pages index ->
                        PageGroup().spread pages
                }
            }
            
            SidebarFooter() {
                SidebarMenu() {
                    SidebarMenuItem(class' = "flex gap-2 items-center") {
                        Motion(
                            hover = JsInterop.jsOptions<MotionStyle>(
                                fun o ->
                                    o.scale <- unbox 1.05
                            )
                        ) {
                            Button(variant = button.variant.ghost, size = button.size.icon).as'(a(href="https://github.com/shayanhabibi/Partas.Solid")) {
                                Github()
                            }
                        }
                        div(class' = "flex flex-col content-between") {
                            Label() { "Lovingly Open Source" }
                            Label(class' = "font-normal") { "Leave a star!" }
                        }
                    }
                }
            }
                        
        }