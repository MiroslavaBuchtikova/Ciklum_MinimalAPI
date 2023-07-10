using System.Text.Json;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Swagger;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CustomerService.Features.Customer.SwaggerDocumentation
{
    public static class GetCustomerConfiguration
    {
        public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
        {
            // Configure the operation properties
            operation.OperationId = "Get customer by Id";
            operation.Summary = "Get customer by Id summary";
            operation.Description = "Get customer by Id description";

            // Configure the request parameter
            var openApiRequestBody = operation.Parameters[0];
            openApiRequestBody.Description = "Request body description";
            openApiRequestBody.Example = new OpenApiString(Guid.NewGuid().ToString());

            // Configure the responses
            operation.Responses = ResponseInfo.GetResponsesInfo();
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
            {
                Example = new OpenApiString(
                    JsonSerializer.Serialize(new CustomerResponseDto(Guid.NewGuid(), "FirstName", "LastName",
                        "EmailAddress")))
            };

            return operation;
        }
    }
}