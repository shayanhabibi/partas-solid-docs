module Partas.Solid.Docs.Sidebar

open Fable.Core
open Partas.Solid.Kobalte
open Partas.Solid.Lucide
open Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Partas.Solid.Motion
open Partas.Solid.UI.Context

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
        let ctx = useSidebar()
        SidebarMenuItem() {
            SidebarMenuButton(
                tooltip = props.title,
                class' = "group/mbutton",
                onClick = fun _ ->
                    if ctx.isMobile() && ctx.openMobile() then ctx.setOpenMobile(false)
                    ).as'(A(href = href(), noScroll = false)) {
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
        props.pages <- [||]
        let isMobile = useIsMobile(false)
        let ctx = useSidebar()
        let collapsible = fun () -> if isMobile() then sidebar.Collapsible.OffCanvas else sidebar.Collapsible.None
        
        Sidebar(
            collapsible = collapsible()
        ).spread(props) {
            
            SidebarHeader() {
                // SidebarInput()
            if isMobile() then
                SidebarMenuAction(onClick = fun _ -> ctx.setOpenMobile(false)) { X() }
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
                                    o.scale <- unbox 1.10
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