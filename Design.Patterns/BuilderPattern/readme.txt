

Builder Pattern
-----------------------------

Separate the construction of a complex object from its representation so that 
the same construction process can create different representations.

The Builder Pattern in Practice:
- Defining an object class ---> Complex object based on some Inputs.
- Adding a builder interface 
- Creating a concrete builder class  ---> Representations created as concrete classes (Constructed from interface blueprint)
- Implement a director class  ---> Director class handles actual object creation
- Update to a Fluent Builder variation

This pattern is very usefull when object creation is sepated through multiple stages or steps.

