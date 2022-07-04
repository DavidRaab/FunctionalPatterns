#!/usr/bin/env -S dotnet fsi

// The whole Decorator Pattern here makes no sense at all. Just use plain data-structures!
// First we create all possible things you can buy.

type Gerichte =
    | HueftSteak
    | Tofu
    | Garnelen
    | WienerSchnitzel
    | Pommes
    | Salat
    | Nudeln
    | Suppe
    | Bratkartoffeln

// Also I put all things into one data-structure. The difference between "Gericht" (dish)
// and "Beilage" (garnish) makes no sense. And adds no extra information.

// Next, we need two functions. One that gets a description of every item, and another
// one that produces the price.

// This is basically just a mapping of one item to a string
let descr dish =
    match dish with
    | HueftSteak      -> "Rump steak"
    | Tofu            -> "Tofu"
    | Garnelen        -> "Shrimp"
    | WienerSchnitzel -> "Wiener Schnitzel"
    | Pommes          -> "Fries"
    | Salat           -> "Salad"
    | Nudeln          -> "Noodles"
    | Suppe           -> "Soup"
    | Bratkartoffeln  -> "Fried Potatoes"

// Here we transform a whole list to a string, not just one item
let description dishs =
    String.concat ", " (List.map descr dishs)

// Same idea here. Mapping from one item to a price
let prc dish =
    match dish with
    | HueftSteak      -> 13.00
    | Tofu            ->  8.50
    | Garnelen        -> 13.50
    | WienerSchnitzel -> 10.50
    | Pommes          ->  2.50
    | Salat           ->  2.25
    | Nudeln          ->  4.50
    | Suppe           ->  1.50
    | Bratkartoffeln  ->  1.50

// Again, just adding all prices together in a list
let price dishs =
    List.sum (List.map prc dishs)

// To "build" a recipe is just to build a list containg dishes.
let dish       = [Salat; Nudeln; HueftSteak]
let dish_desc  = description dish
let dish_price = price dish

printfn "Dish %A contains %s with price of %f" dish dish_desc dish_price

// Program Output:
//
// Dish [Salat; Nudeln; HueftSteak] contains Salad, Noodles, Rump steak with price of 19.750000

// Note:
// You can create a similar solution in C#, Java and so on. But i guess learning OOP makes
// your brain dead and you only can come up with complex solutions.