#!/usr/bin/env -S dotnet fsi

// For this example i show a calculator. But i don't show the parsing yet.
// For an interpreter it makes sense to create a data-structure first.
// Let's assume a calculator with basic Operations.

type Calculator =
    | Value          of float
    | Plus           of Calculator * Calculator
    | Minus          of Calculator * Calculator
    | Multiplication of Calculator * Calculator
    | Division       of Calculator * Calculator

// I usually create functions for the different cases

let value x   = Value x
let plus  x y = Plus          (x, y)
let minus x y = Minus         (x, y)
let mul   x y = Multiplication(x, y)
let div   x y = Division      (x, y)

// Now we can create a whole AST (Abstract-Syntax-Tree)

let calc =
    (mul
        (value 6.0)
        (minus
            (plus (value 2.0) (value 8.0))
            (value 3.0)))

// Now we have beautiful LISP. The above AST represent the following Math
// (6.0 * ((2.0 + 8.0) - 3.0))

// The above is just a data-structure representing what should be done, but
// without doing something. The task of an interpreter is now to write such an
// interpreter. Usually we call this "eval". So let do a "evalRun" to calculate
// the result.

let rec evalRun calc =
    match calc with
    | Value x              -> x
    | Plus (x,y)           -> evalRun x + evalRun y
    | Minus (x,y)          -> evalRun x - evalRun y
    | Multiplication (x,y) -> evalRun x * evalRun y
    | Division (x,y)       -> evalRun x / evalRun y

// Now we can get the result and print it.

printfn "%f" (evalRun calc)

// Program Output:
// 42.000000

// But the idea is to have different Interpreter. So here is an interpreter that converts
// it to a string how we write it in Math.

let rec toMath calc =
    match calc with
    | Value x              -> string x
    | Plus (x,y)           -> sprintf "(%s + %s)" (toMath x) (toMath y)
    | Minus (x,y)          -> sprintf "(%s - %s)" (toMath x) (toMath y)
    | Multiplication (x,y) -> sprintf "(%s * %s)" (toMath x) (toMath y)
    | Division (x,y)       -> sprintf "(%s / %s)" (toMath x) (toMath y)

printfn "%s" (toMath calc)

// Program Output:
// (6 * ((2 + 8) - 3))

// Here is another on that turns it into Lisp-Code

let rec toLisp calc =
    match calc with
    | Value x              -> string x
    | Plus (x,y)           -> sprintf "(+ %s %s)" (toLisp x) (toLisp y)
    | Minus (x,y)          -> sprintf "(- %s %s)" (toLisp x) (toLisp y)
    | Multiplication (x,y) -> sprintf "(* %s %s)" (toLisp x) (toLisp y)
    | Division (x,y)       -> sprintf "(/ %s %s)" (toLisp x) (toLisp y)

printfn "%s" (toLisp calc)

// Program Output:
// (* 6 (- (+ 2 8) 3))

// In this code i focus on the data-structure and its evaluation. Not some kind of parsing.
// If you want to parse stuff i think this should be handled on its own. For example
// you could search for **Parser Combinators** to get to a functional way of parsing stuff.
