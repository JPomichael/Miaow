using System.Web.Routing;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Routes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRouteProvider
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        void RegisterRoutes(RouteCollection routes);

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        int Order { get; }
    }
}
