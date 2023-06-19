using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MinimalAPI.Application.Features.Authorization.Handlers;

public class Get : IRequestHandler<Authorization.Queries.Get, string?>
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public Get(IMemoryCache cache, IMapper mapper, IConfiguration configuration)
    {
        _cache = cache;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<string?> Handle(Authorization.Queries.Get request, CancellationToken cancellationToken)
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