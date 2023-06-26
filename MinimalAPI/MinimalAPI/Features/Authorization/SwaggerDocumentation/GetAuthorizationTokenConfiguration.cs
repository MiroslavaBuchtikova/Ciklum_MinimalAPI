using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Swagger;

namespace MinimalAPI.Features.Authorization.SwaggerDocumentation;

public static class GetAuthorizationTokenConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Get Authorization Token";
        operation.Summary = "Get Authorization Token summary";
        operation.Description = "Get authorization token description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Get authorization token" } };
        var versionParameter = new OpenApiParameter
        {
            Name = "api-version",
            In = ParameterLocation.Query,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "String"
            }
        };
        operation.Parameters.Add(versionParameter);

        operation.Responses = ResponseInfo.GetResponsesInfo();


        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")
        };

        return operation;
    }
}