namespace Revertible
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    /// <summary>
    /// Derived classes are able to save current state of revertible properties and revert their values later if needed.
    /// <pre>NOTICE: You need to annotate the properties of the derived class with <see cref="RevertibleAttribute"/> attribute to make them revertible!</pre>
    /// </summary>
    public class BaseRevertible : IRevertible
    {

        private Dictionary<PropertyInfo, object> m_RevertibleProperties;

        /// <summary>
        /// Returns the <see cref="PropertyInfo"/> for all properties which are annotated with <see cref="RevertibleAttribute"/> in derived class.
        /// </summary>
        /// <returns>Enumerable of <see cref="PropertyInfo"/>.</returns>
        public IEnumerable<PropertyInfo> GetRevertibleProperties() =>
            GetType().GetProperties().Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(RevertibleAttribute)));


        /// <summary>
        /// Returns the <see cref="PropertyInfo"/>s for properties which are annotated with <see cref="RevertibleAttribute"/> and changed value.
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
        /// Contains TRUE if the value of at least one property (which is annotated with <see cref="RevertibleAttribute"/>) has changed/modified, else FALSE.
        /// </summary>
        public bool HasModifiedRevertibleProperties => GetModifiedRevertibleProperties().Any();


        /// <summary>
        /// Reverts value changes for revertible properties annotated with <see cref="RevertibleAttribute"/>.
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
        /// Saves revertible properties which are annotated with <see cref="RevertibleAttribute"/> and their values.
        /// </summary>
        public void SaveRevertibleProperties()
            => m_RevertibleProperties = ((IRevertible)this).GetRevertibleProperties().ToDictionary(p => p, p => p.GetValue(this));
    }
}
