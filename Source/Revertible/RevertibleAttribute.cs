namespace Revertible
{
    using System;

    /// <summary>
    /// Annotated classes and properties are marked as revertibel. See <see cref="BaseRevertible"/> and <seealso cref="IRevertible"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class RevertibleAttribute : Attribute
    {
    }
}
