namespace Revertible
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    /// <summary>
    /// Derived classes are able to save current state of revertible properties and revert their values later if needed.
    /// <pre>You have to mark/associate revertible properties by <see cref="RevertibleAttribute"/> attribute!</pre>
    /// </summary>
    public class BaseRevertible : IRevertible
    {

        private Dictionary<PropertyInfo, object> m_RevertibleProperties;

        /// <summary>
        /// Returns the <see cref="PropertyInfo"/> of all revertible properties in derived class, which have the <see cref="RevertibleAttribute"/> attribute.
        /// </summary>
        /// <returns>Enumerable of <see cref="PropertyInfo"/>.</returns>
        public IEnumerable<PropertyInfo> GetRevertibleProperties() =>
            GetType().GetProperties().Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(RevertibleAttribute)));


        /// <summary>
        /// Returns the <see cref="PropertyInfo"/>s of revertible properties, which their values have been changed/modified.
        /// </summary>
        /// <returns>Enumerable of <see cref="PropertyInfo"/>.</returns>
        public IEnumerable<PropertyInfo> GetModifiedRevertibleProperties()
        {
            if (m_RevertibleProperties != null && m_RevertibleProperties.Any())
            {
                foreach (var kv in m_RevertibleProperties)
                {
                    if (kv.Value == null)
                    {
                        if (kv.Key.GetValue(this) != null)
                            yield return kv.Key;
                    }
                    else if (!kv.Value.Equals(kv.Key.GetValue(this)))
                        yield return kv.Key;
                }
            }
        }


        /// <summary>
        /// Contains TRUE if at least one property has changed/modified value, else FALSE.
        /// </summary>
        public bool HasModifiedRevertibleProperties => GetModifiedRevertibleProperties().Any();


        /// <summary>
        /// Reverts value changes for revertible properties containing <see cref="RevertibleAttribute"/> attribute.
        /// </summary>
        public void RevertRevertibleProperties()
        {
            if (m_RevertibleProperties == null)
                return;

            foreach (var kv in m_RevertibleProperties)
                kv.Key.SetValue(this, kv.Value);

            m_RevertibleProperties = null;
        }


        /// <summary>
        /// Saves revertible properties which are assigned as <see cref="RevertibleAttribute"/> and their value.
        /// </summary>
        public void SaveRevertibleProperties()
            => m_RevertibleProperties = ((IRevertible)this).GetRevertibleProperties().ToDictionary(p => p, p => p.GetValue(this));
    }
}
