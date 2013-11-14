module CommishCalculatorV2.Resource

open FSharp.Data
open System.Xml.Linq

type private File = XmlProvider<"Strings.xml"> // define an xml provider based on the Strings.xml file.

let private strings = File.GetSample() // use the xml file, not as a template, but as the actual file.

let private getXmlData str = // gets the describing string from the file where the input matches the Name.
    strings.GetStrings() 
    |> Array.find (fun attr -> attr.Name = str)

type BaseClass(s: string) = // base class for easy access of the deserialised data in the xml file.
    let _data = getXmlData s

    member this.Value = _data.Value
    member this.Name = _data.Name

let Choose = new BaseClass "choose"

let Price = new BaseClass "price"

let Percent = new BaseClass "percent"