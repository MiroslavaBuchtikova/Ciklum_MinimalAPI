using System.Text.Json;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalAPI.Swagger;

namespace MinimalAPI.Features.Customer.SwaggerDocumentation;

public static class CreateCustomerConfiguration
{
    public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
    {
        operation.OperationId = "CreateCustomerCommand CustomerDto";
        operation.Summary = "CreateCustomerCommand CustomerDto API endpoint";
        operation.Description =
            "CreateCustomerCommand CustomerDto API endpoint: Creates a new customerDto by providing relevant details in the request body and stores the information in the system.";


        var openApiRequestBody = operation.RequestBody;
        openApiRequestBody.Description = "Request body description";
        openApiRequestBody.Content["application/json"].Example = new OpenApiString(
            JsonSerializer.Serialize(new DTOs.CustomerDto("FirstName", "LastName", "EmailAddress"
            )));

        operation.Responses = ResponseInfo.GetResponsesInfo();

        operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
        {
            Example = new OpenApiString(Guid.NewGuid().ToString())
        };

        return operation;
    }
}