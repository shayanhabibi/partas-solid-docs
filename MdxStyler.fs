namespace Partas.Solid.Docs

open Fable.Core
open Fable.Core.JS
open Partas.Solid
open Partas.Solid.UI

[<Import("MDXProvider", "solid-jsx")>]
type MDXProvider() =
    inherit RegularNode()
    [<Erase>] member val components = undefined with get,set

type [<Erase>] Export =
    [<ImportMember("solid-jsx")>]
    static member useMdxComponents: (unit -> unit) = jsNative

[<Erase>]
type MdxStyler() =
    inherit RegularNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        MDXProvider(
        ) {
            div(class' = Lib.cn [|
               "min-w-2/3 pt-12"
               "prose"
               "prose-pre:**:data-highlighted-line:bg-indigo-500/20"
               "prose-pre:**:data-highlighted-chars:bg-teal-500/20"
               "prose-pre:max-h-[600px]"
            |] ) {
                props.children
                div(class' = "min-h-12")
            }
        }
