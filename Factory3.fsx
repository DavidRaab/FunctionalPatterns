#!/usr/bin/env -S dotnet fsi

// Let's assume a Person with just two values. A Gender and a name.

type Gender =
    | Male
    | Female
    | Other

type Person = {
    Gender: Gender
    Name:   string
}

// I usually create a function "create" to create such an Object.

let create gender name = {
    Gender = gender
    Name   = name
}

// We now can write.

let me  = create Male   "David"
let you = create Female "Alice"

// to get two persons. A Factory in OO is usually just a way to simplify creation
// with common arguments. Here we could for example use Partial Application
// to create new functions that create Male and Female.

let createMale   = create Male
let createFemale = create Female

// Partial Application means we don't specifiy all arguments of a function. Here I
// miss the last "name" parameter. The result of this is a new function, that expects
// the next argument. In this case the "name". Now we can write.

let me2  = createMale   "David"
let you2 = createFemale "Alice"

printfn "%A" me
printfn "%A" you
printfn "%A" me2
printfn "%A" you2

// Program Output:
//
// { Gender = Male
//   Name = "David" }
// { Gender = Female
//   Name = "Alice" }
// { Gender = Male
//   Name = "David" }
// { Gender = Female
//   Name = "Alice" }