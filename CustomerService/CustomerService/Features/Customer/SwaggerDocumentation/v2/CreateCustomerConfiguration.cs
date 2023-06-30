using System.Text.Json;
using CustomerService.Features.Customer.DTOs.v2;
using CustomerService.Swagger;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CustomerService.Features.Customer.SwaggerDocumentation.v2
{
    public static class CreateCustomerConfiguration
    {
        public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
        {
            // Configure the operation properties
            operation.OperationId = "CreateCustomer customer";
            operation.Summary = "CreateCustomer customer summary";
            operation.Description = "CreateCustomer API endpoint: Creates a new customerResponseDto by providing relevant details in the request body and stores the information in the system.";

            // Configure the request body
            var openApiRequestBody = operation.RequestBody;
            openApiRequestBody.Description = "Request body description";
            openApiRequestBody.Content["application/json"].Example = new OpenApiString(
                JsonSerializer.Serialize(new CustomerRequestDto( "FirstName", "LastName", "EmailAddress", Gender.Unknown)));

            // Configure the responses
            operation.Responses = ResponseInfo.GetResponsesInfo();
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
            {
                Example = new OpenApiString(Guid.NewGuid().ToString())
            };

            return operation;
        }
    }
}