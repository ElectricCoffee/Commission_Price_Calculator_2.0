module CommishCalculatorV2.Resource

    open FSharp.Data
    open System.Xml.Linq

    type File = XmlProvider<"Strings.xml">

    let strings = File.GetSample()

    [<AbstractClass; Sealed>]
    type Choose = 
        static member Value = (strings.GetStrings() |> Array.find (fun attr -> attr.Name = "choose")).Value

    [<AbstractClass; Sealed>]
    type Price = 
        static member Value = (strings.GetStrings() |> Array.find (fun attr -> attr.Name = "price")).Value

    [<AbstractClass; Sealed>]
    type Percent = 
        static member Value = (strings.GetStrings() |> Array.find (fun attr -> attr.Name = "percent")).Value