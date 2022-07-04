#!/usr/bin/env -S dotnet fsi

// We also could generate a Dish data-structure that contains the information

type Dish = {
    Description: string
    Price:       decimal
}

let dish desc price = { Description = desc; Price = price }

// Now we need to create all dishes with all the data
let hueftsteak = dish "Rump Steak"       13.00m
let tofu       = dish "Tofu"              8.50m
let garnelen   = dish "Shrimp"           13.50m
let schnitzel  = dish "Wiener Schnitzel" 10.50m
let pommes     = dish "Fries"             2.50m
let salat      = dish "Salad"             2.25m
let nudeln     = dish "Noodles"           4.50m
let suppe      = dish "Soup"              1.50m
let kartoffeln = dish "Fried Potatoes"    1.50m

// Here we transform a whole list to a string
let description dishs =
    String.concat ", " (List.map (fun dish -> dish.Description) dishs)

// Again, just adding all prices together in a list
let price dishs =
    List.sum (List.map (fun dish -> dish.Price) dishs)

// To "build" a recipe is just to build a list containg dishes.
let recipe       = [salat; nudeln; hueftsteak]
let recipe_desc  = description recipe
let recipe_price = price recipe

printfn "Dish %A contains %s with price of %f" recipe recipe_desc recipe_price

// Program Output:
//
// Dish [{ Description = "Salad"
//    Price = 2.25M }; { Description = "Noodles"
//                       Price = 4.50M }; { Description = "Rump Steak"
//                                          Price = 13.00M }] contains Salad, Noodles, Rump Steak with price of 19.750000

// Note:
// The difference between both are like being horizontal vs vertical.
//
// In A we define just cases. Every function needs to handle every possible case
// In B we define all data upfront. Now we need to create our objects with all data attached.
//
// With Solution A it is easy to add new functions with new functionality, but harder
// to add new items.
//
// With Solution B it is easier to add new items, but harder to add new functions.
//
// Let's say every item has 100 functions.
//
// With solution A:
// You define your items, and end up with 100 functions. Every function is separated from another.
// Also you have the ability to look into one function, and see how one function operates with every item.
//
// With Solution B:
// Every item contains all data (and in OO all functions) so you have one item and you need
// to overload 100 methods on every class implementation. Solution B is usually what you do in OO
//
// This example is still different as i still only used one common container instead of defining
// 10 different containers that derive from the "Dish" Record. But that is usually what you do
// in OO code.