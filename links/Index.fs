module Partas.Solid.Docs.links.Index

open Partas.Solid.Docs.LinkPopover
open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Lucide

[<Erase>]
type PartasSolidLink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "Solid-js wrapper in Oxpecker Style"
        props.avatar <- "https://github.com/shayanhabibi.png"
        props.fallback <- "SH"
        props.href <- "https://github.com/shayanhabibi/Partas.Solid"
        props.icon <- !@User
        props.caption <- "Author"
        
        LinkCard().spread props

[<Erase>]
type OxpeckerSolidLink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "The original Solid-js wrapper in Fable"
        props.avatar <- "https://github.com/lanayx.png"
        props.fallback <- "LX"
        props.href <- "https://github.com/lanayx/Oxpecker"
        props.icon <- !@User
        props.caption <- "Author of Oxpecker"
        
        LinkCard().spread props

[<Erase>]
type FableLink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "F# |> JS compiler"
        props.avatar <- "https://github.com/fable-compiler.png"
        props.fallback <- "F#"
        props.href <- "https://fable.io"
        props.icon <- !@Users
        props.caption <- "Community maintained"
        LinkCard().spread props
        
[<Erase>]
type SolidUILink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "Beautifully designed components. Built with Kobalte & corvu. Styled with Tailwind CSS."
        props.avatar <- "https://github.com/stefan-karger/solid-ui/raw/main/apps/docs/public/android-chrome-192x192.png"
        props.fallback <- "SU"
        props.href <- "https://www.solid-ui.com"
        LinkCard().spread props

[<Erase>]
type SolidLink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "Simple and performant reactivity for building UI."
        props.avatar <- "https://www.solidjs.com/img/logo/without-wordmark/logo.svg"
        props.fallback <- "SO"
        props.href <- "https://www.solidjs.com"
        LinkCard().spread props

[<Erase>]
type ShadcnLink() =
    inherit LinkCard()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.description <- "Beautifully designed, accessible components and a code distribution platform"
        props.avatar <- "https://github.com/shadcn-ui.png"
        props.fallback <- "SC"
        props.href <- "https://ui.shadcn.com"
        LinkCard().spread props

