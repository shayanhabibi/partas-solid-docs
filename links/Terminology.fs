module Partas.Solid.Docs.links.Terminology

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JS


[<Erase>]
type TerminologyCard() =
    interface RegularNode
    [<Erase>] member val word: string = undefined with get,set
    [<Erase>] member val description: HtmlElement = undefined with get,set
    [<SolidTypeComponent>]
    member props.__ =
        props.word <- ""
        props.description <- unbox ""
        HoverCard() {
            HoverCardTrigger() { span() { props.word } }
            HoverCardContent() {
                div(class' = "flex justify p-2") {
                    props.children
                }
            }
        }

[<SolidComponent>]
let ExtensionMethod () =
    let description =
        p() {
            "These are methods applied to the element IMMEDIATELY after construction:"
            code(lang="fsharp") {
                "div().ExampleMethodExtension()"
            }
        }
    TerminologyCard(word = "extension method") { description }

[<SolidComponent>]
let Tag () =
    let description =
        p() {
            "This refers to the JSX compiled tag of the shape"
        }
    TerminologyCard(word = "tag") { description }

[<SolidComponent>]
let TagComponent () =
    TerminologyCard(word = "tag component") {
        "This refers to a construct which is compiled into a tag.
        Typically this is referring to native elements or user types with members marked with
        the `SolidTypeComponent` attribute. Functions on the other hand,
        are compiled into functions in JSX (which are still valid as components)."
    }

[<SolidComponent>]
let FunctionComponent () =
    TerminologyCard(word = "function component") {
        "This refers (realistically) to any function which returns a type of HtmlElement."
        br()
        "The function does not technically have to be marked with the SolidComponent attribute
        unless it is attempting to render "
        span(class' = "flex") { TagComponent() } 
        "s"
    }

[<SolidComponent>]
let PluginScope () =
    TerminologyCard(word = "plugin scope") {
        "This refers to a scope under a method or function binding that is marked with
        `SolidComponentAttribute` or `SolidTypeComponentAttribute`."
    }

[<SolidComponent>]
let NativeDSL() =
    TerminologyCard(word = "native dsl") {
        "Referring to the Oxpecker Computation Expressions style of expressing the DOM tree"
    }
