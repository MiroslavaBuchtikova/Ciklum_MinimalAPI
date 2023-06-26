using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Swagger;

namespace MinimalAPI.Features.Customer.SwaggerDocumentation;

public static class UpdateCustomerConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "UpdateCustomerCommand CustomerDto";
        operation.Summary = "Updates customerDto summary";
        operation.Description = "Updates CustomerDto description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "UpdateCustomerCommand CustomerDto" } };
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
        var openApiRequestBody = operation.Parameters[0];
        openApiRequestBody.Description = "Request body description";
        openApiRequestBody.Example = new OpenApiString(Guid.NewGuid().ToString());

        operation.Responses = ResponseInfo.GetResponsesInfo();


        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(Guid.NewGuid().ToString())
        };

        return operation;
    }
}