namespace Revertible
{
    using System;

    /// <summary>
    /// Classes and properties marked/associated to this attribute, can be used by <see cref=""/> to save current values and revert them later if needed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class RevertibleAttribute : Attribute
    {
    }
}
