﻿namespace Partas.Solid.ArkUI

open Partas.Solid
open Fable.Core

#nowarn 64
#nowarn 49

[<Interface>]
type ArkUIContext<'T> =
    inherit HtmlElement
    inherit HtmlContainer

[<AutoOpen>]
module Bindings =
    type ArkUIContext<'T> with
        [<Erase>]
        member inline _.Yield(PARTAS_VALUE: Accessor<'T> -> #HtmlElement): HtmlContainerFun = fun PARTAS_CONT -> ignore PARTAS_VALUE