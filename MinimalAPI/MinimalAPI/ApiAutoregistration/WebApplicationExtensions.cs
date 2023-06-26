using System.Reflection;

namespace MinimalAPI.ApiAutoregistration;

public static class WebApplicationExtensions
{
    public static void RegisterApiRoutes(this WebApplication app)
    {
        var routeTypes = GetApiRouteTypes();

        foreach (var routeType in routeTypes)
        {
            var route = Activator.CreateInstance(routeType) as IApiRoute;
            route.Register(app); 
        }
    }


    private static IEnumerable<Type> GetApiRouteTypes()
    {
        var apiRouteType = typeof(IApiRoute);
        var concreteTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => apiRouteType.IsAssignableFrom(type) && !type.IsAbstract);

        return concreteTypes;
    }
}