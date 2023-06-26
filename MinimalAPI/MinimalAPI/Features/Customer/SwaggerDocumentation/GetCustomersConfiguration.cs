using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Swagger;

namespace MinimalAPI.Features.Customer.SwaggerDocumentation;

public static class GetCustomersConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Get Customers";
        operation.Summary = "Get customers summary";
        operation.Description = "Get Customers description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Get Customers" } };
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
                JsonSerializer.Serialize(new List<DTOs.CustomerDto>()
                {
                    new CustomerDto("Firstname", "Lastname", "EmailAddress")
                }))
        };

        return operation;
    }
}