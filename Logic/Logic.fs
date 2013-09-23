module CommishCalculatorV2.Logic

let formatter (price:float) (currency:string) (extraCharacters:float) (inputFunction: float -> float -> int -> float) =
    let partialInput = inputFunction price extraCharacters in
        
    let (result, items) = (List.map partialInput [1..10], [1..10]) in

    List.map2 (fun r i -> sprintf " %i Characters: %s %f" i currency r) result items

let selectionChanged input currency = 
    match input with
        | _ when input = Resource.Choose.Value -> "   "
        | _ when input = Resource.Price.Value -> currency
        | _ when input = Resource.Percent.Value -> "%"
        | _ -> "ERROR"

let saveButtonClick (price:float) (currency:string) (additionalOption:string) (extraCharacters:float) =
    let formatHelper (inputFunction: float -> float -> int -> float) = 
        formatter price currency extraCharacters inputFunction in
    let result = 

        let adder = fun p m n -> p + m * float n
        let percenter = fun p m n -> ((float n + 1.0) * p) - ((float n + 1.0) * p) * (m / 100.0)

        match additionalOption with
            | _ when additionalOption = Resource.Price.Value -> Some (formatHelper adder)
            | _ when additionalOption = Resource.Percent.Value -> Some (formatHelper percenter)
            | _ -> None

    match result with
        | Some(strLst) -> strLst
        | None -> "E"::"R"::"R"::[]