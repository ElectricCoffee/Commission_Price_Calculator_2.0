module CommishCalculatorV2.Logic

    open System.IO

    let formatter (price:float) (currency:string) (extraCharacters:float) (inputFunction: float -> float -> int -> float) =
        let partialInput = inputFunction price extraCharacters in
        
        let (result, items) = (List.map partialInput [1..10], [1..10]) in

        List.map2 (fun r i -> sprintf " %i Characters: %s %f" i currency r) result items

    let selectionChanged input currency = 
        match input with
            | "Choose One..." -> "   "
            | "Price Per Character" -> currency
            | "Percent Saved" -> "%"
            | _ -> "ERROR"

    let saveButtonClick (price:float) (currency:string) (additionalOption:string) (extraCharacters:float) =
        let formatHelper (inputFunction: float -> float -> int -> float) = 
            formatter price currency extraCharacters inputFunction in
        let result = 
            match additionalOption with
                | "Price Per Character" -> Some (formatHelper (fun p -> (fun m -> (fun n -> p + m * float n))))
                | "Percent Saved" -> Some (formatHelper (fun p -> (fun m -> (fun n -> ((float n + 1.0) * p) - ((float n + 1.0) * p) * (m / 100.0)))))
                | _ -> None

        match result with
            | Some(strLst) -> strLst
            | None -> "E"::"R"::"R"::"O"::"R"::[]