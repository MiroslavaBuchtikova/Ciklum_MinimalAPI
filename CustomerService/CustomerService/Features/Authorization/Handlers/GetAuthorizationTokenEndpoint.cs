using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace CustomerService.Features.Authorization.Handlers;

public class GetAuthorizationTokenEndpoint : IRequestHandler<Queries.GetAuthorizationTokenQuery, string>
{
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public GetAuthorizationTokenEndpoint(IMemoryCache cache, IConfiguration configuration)
    {
        _cache = cache;
        _configuration = configuration;
    }

    public async Task<string> Handle(Queries.GetAuthorizationTokenQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = "auth_token";

        if (_cache.TryGetValue(cacheKey, out string jwtToken))
        {
            return jwtToken;
        }

        var issuer = _configuration.GetSection("Jwt")["Issuer"];
        var audience = _configuration.GetSection("Jwt")["Audience"];
        var secretKey = _configuration.GetSection("Jwt")["Key"];

        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = handler.CreateToken(descriptor);

        jwtToken = handler.WriteToken(token);
        _cache.Set(cacheKey, jwtToken, TimeSpan.FromMinutes(25));

        return jwtToken;
    }
}