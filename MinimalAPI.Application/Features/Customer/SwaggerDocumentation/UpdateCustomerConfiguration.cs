using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Application.Swagger;

namespace MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

public static class UpdateCustomerConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Update Customer";
        operation.Summary = "Updates customer summary";
        operation.Description = "Updates Customer description";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Update Customer" } };
        
        var openApiRequestBody = operation.Parameters[0];
        openApiRequestBody.Description = "Request body description";
        openApiRequestBody.Example = new OpenApiString(Guid.NewGuid().ToString());

        operation.Responses = ResponseInfo.GetResponsesInfo();


        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(
                JsonSerializer.Serialize(new Core.Entities.Customer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "FirstName",
                    LastName = "LastName",
                    EmailAddress = "EmailAddress"
                }))
        };

        return operation;
    }
}