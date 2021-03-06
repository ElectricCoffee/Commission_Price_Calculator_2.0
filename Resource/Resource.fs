﻿module CommishCalculatorV2.Resource

open FSharp.Data
open System.Xml.Linq

type private File = XmlProvider<"Strings.xml">

let private strings = File.GetSample()

let private getXmlData str = 
    strings.GetStrings() 
    |> Array.find (fun attr -> attr.Name = str)

type BaseClass(s: string) =
    let _str = s
    let _data = getXmlData _str

    member this.Value = _data.Value
    member this.Name = _data.Name

let Choose = new BaseClass "choose"

let Price = new BaseClass "price"

let Percent = new BaseClass "percent"