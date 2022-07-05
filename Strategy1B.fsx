#!/usr/bin/env -S dotnet fsi

module Bill =
    type Strategy =
        | Normal
        | Happy

    type Entry = {
        Strategy: Strategy
        Name:     string
        Price:    decimal
        Quantity: int
    }

    let create strategy name price qty =
        { Strategy = strategy; Name = name; Price = price; Quantity = qty }

    let createNormal = create Normal
    let createHappy  = create Happy

    let str bill =
        match bill.Strategy with
        | Normal -> sprintf " * %s %.2f€ x %d"                    bill.Name  bill.Price         bill.Quantity
        | Happy  -> sprintf " * %s %.2f€ x %d -- HAPPY HOUR 50%%" bill.Name (bill.Price * 0.5m) bill.Quantity

    let totalPrice bills =
        bills
        |> List.map (fun bill ->
            match bill.Strategy with
            | Normal -> bill.Price * decimal bill.Quantity
            | Happy  -> bill.Price * decimal bill.Quantity * 0.5m)
        |> List.sum

    let toString bills =
        String.concat "\n"
            (List.append
                (List.map str bills)
                ["Summary: " + string (totalPrice bills) + "€"])


let firstCustomer = [
    Bill.createNormal "Beer" 1.0m 1
    Bill.createHappy  "Beer" 1.0m 2
]

let secondCustomer = [
    Bill.createHappy  "Shot"       0.8m 1
    Bill.createNormal "Beer Lemon" 1.3m 2
    Bill.createNormal "Vodka"      2.5m 1
]

printfn "%A" firstCustomer
printfn "%A" secondCustomer

// firstCustomer and secondCustomer are just Data-Structures
// containing all relevant informations.

// firstCustomer:
// [{ Strategy = Normal; Price = 1.0M; Quantity = 1 };
//  { Strategy = Happy;  Price = 1.0M; Quantity = 2 }]

// secondCustomer:
// [{ Strategy = Happy;  Price = 0.8M; Quantity = 1 };
//  { Strategy = Normal; Price = 1.3M; Quantity = 2 };
//  { Strategy = Normal; Price = 2.5M; Quantity = 1 }]

printfn "First Customer:\n%s"  (Bill.toString firstCustomer)
printfn ""
printfn "Second Customer:\n%s" (Bill.toString secondCustomer)

// Program Output
//
// First Customer:
//  * Beer 1.00€ x 1
//  * Beer 0.50€ x 2 -- HAPPY HOUR 50%
// Summary: 2.00€

// Second Customer:
//  * Shot 0.40€ x 1 -- HAPPY HOUR 50%
//  * Beer Lemon 1.30€ x 2
//  * Vodka 2.50€ x 1
// Summary: 5.50€