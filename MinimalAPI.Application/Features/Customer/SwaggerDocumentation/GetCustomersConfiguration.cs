using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Application.Swagger;

namespace MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

public static class GetCustomersConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Get Customers";
        operation.Summary = "Get customers summary";
        operation.Description = "Get Customers description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Get Customers" } };


        operation.Responses = ResponseInfo.GetResponsesInfo();


        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(
                JsonSerializer.Serialize(new List<DomainModels.Customer>()
                {
                    new()
                    {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    EmailAddress = "EmailAddress"}
                }))
        };

        return operation;
    }
}