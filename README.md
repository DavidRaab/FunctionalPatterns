I created this project alongside a video called: **Functional Pattern in F#**

You can find this video on YouTube: https://youtu.be/XiG-uuNKzF8

In my version I used different styles how to solve problems.
Also look into revisions to see how I probably changed solutions over time.

# Builder.fsx

Instead of directly creating functions with a string output i use a data-structure.
Using a data-structure has many advantages. For example you need only one
function to create proper HTML code with escaping and user rules. Instead of
re-doing this, again and again.

You also can create structures that can be easily re-used.

# Decorator

* Decorator2.java - A "good" Java Example of Decorators
* Decorator2A.fsx - Solution with DU and plain functions
* Decorator2B.fsx - Solution with a common Record
