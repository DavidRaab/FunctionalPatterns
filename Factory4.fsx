#!/usr/bin/env -S dotnet fsi

// You can find this example here: https://www.tutorialspoint.com/design_pattern/factory_pattern.htm
// This is a common Shape Problem in Java. It looks like this.

(*
public interface Shape {
    void draw();
}

public class Rectangle implements Shape {
    @Override
    public void draw() {
        System.out.println("Inside Rectangle::draw() method.");
   }
}

public class Square implements Shape {
    @Override
    public void draw() {
        System.out.println("Inside Square::draw() method.");
    }
}

public class Circle implements Shape {
    @Override
    public void draw() {
        System.out.println("Inside Circle::draw() method.");
    }
}
*)

// The Shape structure again is just a DU. And i would extract the function instead
// of trying to implement it for every type.

type Shape =
    | Rectangle
    | Square
    | Circle

let draw shape =
    match shape with
    | Rectangle -> "Drawing a Rectangle"
    | Square    -> "Drawing a Square"
    | Circle    -> "Drawing a Circle"

// The Java example goes on with the following Factory

(*
public class ShapeFactory {
   //use getShape method to get object of type shape
   public Shape getShape(String shapeType){
      if(shapeType == null){
         return null;
      }
      if(shapeType.equalsIgnoreCase("CIRCLE")){
         return new Circle();

      } else if(shapeType.equalsIgnoreCase("RECTANGLE")){
         return new Rectangle();

      } else if(shapeType.equalsIgnoreCase("SQUARE")){
         return new Square();
      }

      return null;
   }
}
*)

// The idea is to create a different shape based on a string. This can make sense
// if you for example get a string from a text file, database or whatever.

let fromString shape =
    match shape with
    | "Rectangle" -> Rectangle
    | "Circle"    -> Circle
    | "Square"    -> Square
    | _           -> failwith "String not supported."

// Now they use the Factory like this

(*
public class FactoryPatternDemo {
   public static void main(String[] args) {
      ShapeFactory shapeFactory = new ShapeFactory();

      //get an object of Circle and call its draw method.
      Shape shape1 = shapeFactory.getShape("CIRCLE");

      //call draw method of Circle
      shape1.draw();

      //get an object of Rectangle and call its draw method.
      Shape shape2 = shapeFactory.getShape("RECTANGLE");

      //call draw method of Rectangle
      shape2.draw();

      //get an object of Square and call its draw method.
      Shape shape3 = shapeFactory.getShape("SQUARE");

      //call draw method of square
      shape3.draw();
   }
}
*)

let shape1 = fromString "Circle"
draw shape1 |> printfn "%s"

let shape2 = fromString "Rectangle"
draw shape2 |> printfn "%s"

let shape3 = fromString "Square"
draw shape3 |> printfn "%s"

// Program Output:
//
// Drawing a Circle
// Drawing a Rectangle
// Drawing a Square