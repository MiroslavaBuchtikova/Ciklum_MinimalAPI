namespace MinimalAPI.Autoregistration;

public static class WebApplicationExtensions
{
    public static void RegisterApiRoutes(this WebApplication app)
    {
        var type = typeof(IApiRoute);
        var types = type.Assembly.GetTypes().Where(p => p.IsClass && p.IsAssignableTo(type));

        foreach (var routeType in types)
        {
            var route = (IApiRoute)Activator.CreateInstance(routeType);

            route.Register(app);
        }
    }
}