namespace MinimalAPI.ApiAutoregistration;

public interface IApiRoute
{
    void Register(WebApplication group);
}