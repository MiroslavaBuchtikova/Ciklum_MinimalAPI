using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Application.Swagger;

namespace MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

public static class CreateCustomerConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "Create Customer";
        operation.Summary = "Create Customer API endpoint";
        operation.Description =
            "Create Customer API endpoint: Creates a new customer by providing relevant details in the request body and stores the information in the system.";
        operation.Tags = new List<OpenApiTag> { new() { Name = "Create Customer" } };

        var openApiRequestBody = operation.RequestBody;
        openApiRequestBody.Description = "Request body description";
        openApiRequestBody.Content["application/json"].Example = new OpenApiString(
            JsonSerializer.Serialize(new DomainModels.Customer()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                EmailAddress = "EmailAddress"
            }));

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