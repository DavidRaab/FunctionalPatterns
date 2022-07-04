#!/usr/bin/env -S dotnet fsi

// Now we look at an C# example you find here: https://en.wikipedia.org/wiki/Factory_method_pattern#C#
// I just post the code, i guess you will understand it.

//
// public interface IPerson
// {
//     string GetName();
// }

// public class Villager : IPerson
// {
//     public string GetName()
//     {
//         return "Village Person";
//     }
// }

// public class CityPerson : IPerson
// {
//     public string GetName()
//     {
//         return "City Person";
//     }
// }

// public enum PersonType
// {
//     Rural,
//     Urban
// }

// public class Factory
// {
//     public IPerson GetPerson(PersonType type)
//     {
//         switch (type)
//         {
//             case PersonType.Rural:
//                 return new Villager();
//             case PersonType.Urban:
//                 return new CityPerson();
//             default:
//                 throw new NotSupportedException();
//         }
//     }
// }

// First, the structure is that there are "Villager" and "CityPerson" that inherit
// from a base class "IPerson". This is a common structure that you represent with a
// Discriminated Union (DU) in F#

type Person =
    | Villager   of name:string
    | CityPerson of name:string

// Now the Factory for some reasons take a enum with "Rural" or "Urban" that either creates
// a Villager or CityPerson. Again, DU to the rescue!

type PersonType =
    | Rural
    | Urban

// Now we can create a Factory function

let create personType =
    match personType with
    | Rural -> Villager   "Village Person"
    | Urban -> CityPerson "City Person"

// In F# we don't need to handle a default value. Because Discriminated Unions are
// complete. What i mean with this is. A DU is not a number like enum. Every case is
// in some sense a class on its own that can attach different data to ot.
// On top, F# would give us errors if we don't pattern match against every
// DU case that exists. And we only can provide those cases that are defined. So there
// is no exception throwing needed or even possible!

let p1 = create Rural
let p2 = create Urban

printfn "%A" p1
printfn "%A" p2

// Program Output:
//
// Villager "Village Person"
// CityPerson "City Person"

// Personal Opinion: A Factory makes nearly no sense instead we could create
// Functions on its own.

let createVillager   = Villager "Village Person"
let createCityPerson = CityPerson "City Person"

let p3 = createVillager
let p4 = createCityPerson

printfn "%A" p3
printfn "%A" p4

// Program Output:
//
// Villager "Village Person"
// CityPerson "City Person"
