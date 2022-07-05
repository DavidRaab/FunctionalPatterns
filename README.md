# Overview

This project shows different OO Design Patterns and how I solve them
in F#

## Builder

Instead of directly creating functions with a string output i use a data-structure.
Using a data-structure has many advantages. For example you need only one
function to create proper HTML code with escaping and user rules. Instead of
re-doing this, again and again.

You also can create structures that can be easily re-used.

## Decorator

* Decorator1.fsx  - Example from Video - I would change nothing
* Decorator2.java - A "good" Java Example of Decorators
* Decorator2A.fsx - Solution with DU and plain functions
* Decorator2B.fsx - Solution with a common Record

## Factory

* Factory1.fsx - PHP CarFactory example re-written in F#
* Factory2.fsx - Wikipedia IPerson example re-writte in F#
* Factory3.fsx - My own Example showing Partial Application
* Factory4.fsx - A Java Example with Shapes converted to F#

## Interpreter

* Interpreter1.fsx - A simple Calculator

## Strategy

* Strategy1.cs   - C# Example from Wikipedia
* Strategy1A.fsx - A more direct conversation of the C# version
* Strategy2B.fsx - An extended version that creates a data-structure

## Further Resources

I started this project by watching a video, but then it turned into something different.
Here are various resources I used to create this project.

* Functional Patterns: https://youtu.be/XiG-uuNKzF8
* Decorato2.java: https://www.philipphauer.de/study/se/design-pattern/decorator.php
* Factory1.fsx: https://www.ionos.de/digitalguide/websites/web-entwicklung/was-ist-das-factory-pattern/
* Factory2.fsx: https://en.wikipedia.org/wiki/Factory_method_pattern#C#
* Factory4.fsx: https://www.tutorialspoint.com/design_pattern/factory_pattern.htm
* Strategy1.fsx: https://en.wikipedia.org/wiki/Strategy_pattern#C#
