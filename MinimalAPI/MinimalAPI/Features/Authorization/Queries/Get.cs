using MediatR;

namespace MinimalAPI.Features.Authorization.Queries;

public record Get : IRequest<string>;