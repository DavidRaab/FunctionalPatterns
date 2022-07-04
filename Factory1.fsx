#!/usr/bin/env -S dotnet fsi

// We start with an PHP Example, that you can find here:
// https://www.ionos.de/digitalguide/websites/web-entwicklung/was-ist-das-factory-pattern/
//
// There we have a Car Class

// class Car {
//     private $color = null;
//         public function __construct() {
//         $this->color = "white";
//     }
//     public function setColor($color) {
//         $this->color = $color;
//     }
//     public function getColor() {
//         return $this->color;
//     }
// }

// Currently it would create white cars. But we want to create cars with different colors.
// To "simplify" (i absolutely don't know what you can simplify here) but anyway people do
// the fololowing stuff.

// class CarFactory {
//     private function __construct() {
//     }
//     public static function getBlueCar() {
//         return self::getCar("blue");
//     }
//     public static function getRedCar() {
//         return self::getCar("red");
//     }
//     private static function getCar($color) {
//         $car = new Car();
//         $car->setColor($color);
//         return $car;
//     }
// }

// Now with "CarFactory::getBlueCar()" we could get a blue car.

// In F# the Car would be a Record

type Car = {
    Color: string
}

// Now we create a helper function to create such a record
let create color = { Color = color }

// Now we can create different cars like this.
let white = create "White"
let blue  = create "Blue"
let red   = create "Red"

// We also can use Partial Application, but with only one argument that doesn't
// make much sense. You could re-use all the variable above, without ever creating
// more cars because they are all immutable. So "white" refers to a white car, and will
// never change. But let's assume you would have some kind of mutable data in it. And
// you want another function to always create white cars. Then you write:

let createWhiteCar () =
    create "White"

let whiteCar1 = createWhiteCar ()
let whiteCar2 = createWhiteCar ()

// The Factory Pattern is nearly obsolete in a Functional language, becaue they are just
// functions that create stuff!
