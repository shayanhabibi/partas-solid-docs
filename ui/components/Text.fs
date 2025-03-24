﻿namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

module textFieldInput =
    [<StringEnum(CaseRules.KebabCase)>]
    type Type =
        | Button
        | Checkbox
        | Color
        | Date
        | DatetimeLocal
        | Email
        | File
        | Hidden
        | Image
        | Month
        | Number
        | Password
        | Radio
        | Range
        | Reset
        | Search
        | Submit
        | Tel
        | Text
        | Time
        | Url
        | Week
    
[<Erase>]
module label =
    let variants =
        Lib.cva
            "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
            {|
                variants = {|
                    variant = {|
                        label = "data-[invalid]:text-destructive"
                        description = "font-normal text-muted-foreground"
                        error = "text-xs text-destructive"
                    |}
                |}
                defaultVariants = {|
                    variant = "label"
                |}
            |}
        
[<Erase>]
type TextField() =
    inherit Kobalte.TextField()
    [<SolidTypeComponentAttribute>]
    member props.construc =
        Kobalte.TextField(class' = Lib.cn [| "flex flex-col gap-1"; props.class' |])
            .spread props

[<Erase>]
type TextFieldInput() =
    inherit TextField.Input()
    member val type': textFieldInput.Type = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.type' <- textFieldInput.Text
        TextField.Input(class' = Lib.cn [|
            "flex h-10 w-full rounded-md border border-input bg-transparent px-3 py-2 text-sm ring-offset-background file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50 data-[invalid]:border-error-foreground data-[invalid]:text-error-foreground"
            props.class'
        |], type' = unbox<string> props.type').spread props

[<Erase>]
type TextFieldTextArea() =
    inherit TextField.TextArea()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        TextField.TextArea(class' = Lib.cn [|
            "flex min-h-[80px] w-full rounded-md border border-input bg-background px-3 py-2 text-sm ring-offset-background placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50"
            props.class'
        |]).spread props

[<Erase>]
type TextFieldLabel() =
    inherit TextField.Label()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        TextField.Label(class' = Lib.cn [|
            label.variants()
            props.class'
        |]).spread props

[<Erase>]
type TextFieldDescription() =
    inherit TextField.Description()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        TextField.Description(class' = Lib.cn [|
            label.variants({|variant = "description" |})
            props.class'
        |]).spread props

[<Erase>]
type TextFieldErrorMessage() =
    inherit TextField.ErrorMessage()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        TextField.ErrorMessage(class' = Lib.cn [| label.variants({| variant = "error" |}); props.class' |])
            .spread props