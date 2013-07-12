namespace iPow.Infrastructure.Crosscutting.Adapters
{
    /// <summary>
    /// Base contract for map dto to aggregate or aggregate to dto.
    /// <remarks>
    /// This is a  contract for work with "auto" mappers ( automapper,emitmapper,valueinjecter...)
    /// or adhoc mappers
    /// </remarks>
    /// </summary>
    public interface ITypeAdapter
    {
        /// <summary>
        /// Adapt a source object to an instance of type <paramref name="KTarget"/>
        /// </summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns>
        /// 	<paramref name="source"/> mapped to <typeparamref name="TTarget"/>
        /// </returns>
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TTarget : class,new()
            where TSource : class;


        /// <summary>
        /// Adapt a source object to an instance of type <paramref name="KTarget"/> using
        /// nested object for map completion
        /// </summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance of source to map</param>
        /// <param name="moreSources">More sources for mapping</param>
        /// <returns>
        /// 	<paramref name="source"/> mapped to <typeparamref name="TTarget"/>
        /// </returns>
        TTarget Adapt<TSource, TTarget>(TSource source, params object[] moreSources)
            where TTarget : class,new()
            where TSource : class;
    }
}
