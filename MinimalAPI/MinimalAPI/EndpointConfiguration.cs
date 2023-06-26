using Asp.Versioning.Builder;

namespace MinimalAPI;

public class EndpointConfiguration
{
    public const string BaseApiPath = "api/v{version:apiVersion}";
    public static ApiVersionSet VersionSet { get; private set; } = default!;
}