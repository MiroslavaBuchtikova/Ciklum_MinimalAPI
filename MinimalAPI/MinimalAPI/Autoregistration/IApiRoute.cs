namespace MinimalAPI.Autoregistration;

public interface IApiRoute
{
    void Register(WebApplication group);
}