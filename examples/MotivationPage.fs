module Partas.Solid.Docs.examples.MotivationPage

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<SolidComponent>]
let AccordionExample () =
    div(class' = "flex items-center justify-center") {
        Accordion(
            multiple = false,
            collapsible = true,
            // 'not-prose' disables the markdown styling
            class' = "not-prose w-full max-w-3xl align-center"
        ) {
            AccordionItem(value = "item-1")
                {
                    AccordionTrigger() { "Is it accessible?" }
                    AccordionContent() { "Yes, it adheres to the WAI-
                                         ARIA design pattern." }
                }
            AccordionItem(value = "item-2")
                {
                    AccordionTrigger() { "Is it styled?" }
                    AccordionContent() { "Yes, it comes with default
                                         styles that matches the other
                                         components' aesthetic." }
                }
            AccordionItem(value = "item-3")
                {
                    AccordionTrigger() { "Is it animated?" }
                    AccordionContent() { "Yes, it's animated by default,
                                         but you can disable it if you prefer" }
                }   
        }
    }
