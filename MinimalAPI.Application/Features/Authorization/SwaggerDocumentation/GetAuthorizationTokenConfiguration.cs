using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Application.Swagger;

namespace MinimalAPI.Application.Features.Authorization.SwaggerDocumentation;

public static class GetAuthorizationTOkenConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Get Authorization Token";
        operation.Summary = "Get Authorization Token summary";
        operation.Description = "Get authorization token description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Get authorization token" } };


        operation.Responses = ResponseInfo.GetResponsesInfo();


        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")
        };

        return operation;
    }
}