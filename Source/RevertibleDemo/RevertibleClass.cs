

namespace RevertibleDemo
{
using Revertible;

// Assigning the class with [Revertible] is not necessary,
// if you don't want/need to access IRevertible methods outside of the class.
[Revertible]
public class RevertibleClass : BaseRevertible // Derive your class from BaseRevertible, so you don't need to implement IRevertible explicitely by yourself.
{
    // Just assign [Revertible] attribute to properties which should be able to save and revert their values.
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }
}
}
