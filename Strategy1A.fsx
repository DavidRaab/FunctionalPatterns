#!/usr/bin/env -S dotnet fsi

// Historical the Strategy Pattern is actually just the idea of functional
// programming and passing a functions around. Let's look at this C#
// code

(*
interface IBillingStrategy
{
    double GetActPrice(double rawPrice);
}

// Normal billing strategy (unchanged price)
class NormalStrategy : IBillingStrategy
{
    public double GetActPrice(double rawPrice) => rawPrice;
}

// Strategy for Happy hour (50% discount)
class HappyHourStrategy : IBillingStrategy
{
    public double GetActPrice(double rawPrice) => rawPrice * 0.5;
}
*)

// Every interface with one Method is actually just a function!
// Here we just define a function that takes a **double* as input and returns a *double*
// But in classic OO there were no lambda (inline-functions) so you must create an interface
// and two classes with these implemtations.
//
// In a functional language the above code are just 2 functions

let normalStrategy x = x
let happyStrategy  x = x * 0.5m

// The CustomerBill class in C# is actually just a container adding the prices to
// an internal list. But before adding the values, it passes the value given in 'Add'
// to the lambda.

(*
class CustomerBill
{
    private IList<double> drinks;

    // Get/Set Strategy
    public IBillingStrategy Strategy { get; set; } // <-- Is a reference to a function

    public CustomerBill(IBillingStrategy strategy)
    {
        this.drinks = new List<double>();
        this.Strategy = strategy;
    }

    public void Add(double price, int quantity)
    {
        this.drinks.Add(
            this.Strategy.GetActPrice(price * quantity) // <-- Here the function is
                                                        //     executed before adding to the list
        );
    }

    ....
*)

// Let me Show you the Record with a member Print in F#

type CustomerBill = {
    Drinks: list<decimal>
}
    with
    member this.Print () =
        sprintf "Total due: %.2f" (List.sum this.Drinks)

// I provide an empty CustomerBill as a starting point

let empty = { Drinks = [] }

// Instead that CustomerBill stores a function-pointer to the strategy
// i expect the strategy as an argument to *add*.

let add strategy price qty bill =
    let price = strategy (price * decimal qty)
    { Drinks = List.append bill.Drinks [price] }

// Now we can create the firstCustomer
let firstCustomer =
    empty
    |> add normalStrategy 1.0m 1
    |> add happyStrategy  1.0m 2

// The second Customer
let secondCustomer =
    empty
    |> add happyStrategy  0.8m 1
    |> add normalStrategy 1.3m 2
    |> add normalStrategy 2.5m 1

// And get the result
printfn "%s" (firstCustomer.Print  ())
printfn "%s" (secondCustomer.Print ())

// Program Output:
// Total due: 2.00
// Total due: 5.50

// We also could easily store the Strategy separetely in CustomerBill
// and provide a 'setStrategy' function, more like the C# version.
// But overall this is probably uncommon in a functional language. Its
// common to just pass a function where it is needed.
//
// In Strategy2.fsx i solve the whole problem in a different way.