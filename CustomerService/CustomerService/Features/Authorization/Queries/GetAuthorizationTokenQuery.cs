using MediatR;

namespace CustomerService.Features.Authorization.Queries;

public record GetAuthorizationTokenQuery : IRequest<string>;