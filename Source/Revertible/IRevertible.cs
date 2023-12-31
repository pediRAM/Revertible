namespace Revertible
{
    using System.Collections.Generic;
    using System.   Reflection;


    /// <summary>
    /// Defines methods to save and revert revertible properties and their values, which are annotated with <see cref="RevertibleAttribute"/>.
    /// </summary>
    public interface IRevertible
    {
        /// <summary>
        /// Returns the <see cref="PropertyInfo"/> of all revertible properties in derived class, which have the <see cref="RevertibleAttribute"/> attribute.
        /// </summary>
        /// <returns>Enumerable of <see cref="PropertyInfo"/>.</returns>
        IEnumerable<PropertyInfo> GetRevertibleProperties();


        /// <summary>
        /// Returns the <see cref="PropertyInfo"/>s of revertible properties, which have modified/new values.
        /// </summary>
        /// <returns>Enumerable of <see cref="PropertyInfo"/>.</returns>
        IEnumerable<PropertyInfo> GetModifiedRevertibleProperties();


        /// <summary>
        /// Contains TRUE if at least one property has changed/modified value, else FALSE.
        /// </summary>
        bool HasModifiedRevertibleProperties { get; }


        /// <summary>
        /// Saves revertible properties which are assigned as <see cref="RevertibleAttribute"/> and their value.
        /// </summary>
        void SaveRevertibleProperties();


        /// <summary>
        /// Reverts value changes for revertible properties containing <see cref="RevertibleAttribute"/> attribute.
        /// </summary>
        void RevertRevertibleProperties();
    }
}
