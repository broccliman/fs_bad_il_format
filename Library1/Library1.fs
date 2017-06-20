namespace Library1

type Bar() =
    inherit ClassLibrary1.Foo2()
    override this.Print() = base.Print()
