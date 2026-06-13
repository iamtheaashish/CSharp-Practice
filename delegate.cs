Console.WriteLine("Hello World");
Transformer t = Square;

Console.WriteLine(t(3));


int Square (int x) => x * x;
delegate int Transformer (int x);

/*
A delegate is an object that knows how to call a method.

A delegate type defines the kind of method that delegate instances can call.
Specifically, it defines the method’s return type and its parameter types.

A delegate instance literally acts as a delegate for the caller: the caller
invokes the delegate, and then the delegate calls the target method. This
indirection decouples the caller from the target method
*/
