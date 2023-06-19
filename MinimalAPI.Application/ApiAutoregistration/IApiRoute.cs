using Microsoft.AspNetCore.Builder;

namespace MinimalAPI.Application.ApiAutoregistration;

public interface IApiRoute
{
    void Register(WebApplication group);
}