module Partas.Solid.Docs.Types

open Partas.Solid
open Partas.Solid.Primitives.Media
open Fable.Core

[<Erase; AutoOpen>]
module Navigation =
    type NavigationItem =
        {
            Title: string
            Icon: TagValue option
            Path: string
        }
    type NavigationGroup =
        {
            Title: string
            Icon: TagValue option
            Items: NavigationItem[]
        }
    
    [<Erase>]
    module NavigationItem =
        let create title path icon =
            {
                Title = title
                Path = path
                Icon = icon
            }
        let init = create "" "" None
    [<Erase>]
    module NavigationGroup =
        let create title icon items =
            {
                Title = title
                Icon = icon
                Items = items
            }
        let init = create "" None [||]

[<Erase>]
module Data =
    [<Erase>]
    module Navigation =
        let data, store = createStore<NavigationGroup[]>([||])
    [<Erase>]
    module Window =
        let isMobile = createMediaQuery $"(max-width:{1023}px)"
