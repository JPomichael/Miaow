namespace iPow.Infrastructure.Crosscutting.Adapters
{
    /// <summary>
    /// Base contract type map configurations
    /// </summary>
    public interface ITypeMapConfigurationBase
    {
        /// <summary>
        /// Get descriptor for this instance.
        /// <remarks>
        /// This descriptor is not unique string.
        /// </remarks>
        /// </summary>
        /// <value>The descriptor.</value>
        string Descriptor { get; }
    }
}
