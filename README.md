When calling `base.XYZ` in a derived class, and member `XYZ` in the base is abstract, we expect to get a compiler error like: https://docs.microsoft.com/en-us/dotnet/csharp/misc/cs0205

F# behaves the same way. The following will give an F# compile time error:
```
[<AbstractClass>]
type Foo() =
    abstract member Print : unit -> unit

type Bar() =
    inherit Foo()

    override this.Print () = base.Print ()
```
If you move the `Foo` type to a C# project, F# will continue to give a compile time error:
```
public abstract class Foo { protected abstract void Print(); }

type Bar() =
    inherit Foo()

    override this.Print () = base.Print ()
```
If you introduce another level of abstract inheritance in the C# project, F# will no longer give a compiler error; instead, you will get a "Bad IL format." exception at runtime when calling `Print`.
```
public abstract class Foo { protected abstract void Print(); }
public abstract class Foo2 : Foo { }

type Bar() =
    inherit Foo2()

    override this.Print () = base.Print ()
```