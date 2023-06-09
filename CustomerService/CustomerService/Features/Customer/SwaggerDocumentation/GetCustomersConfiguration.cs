using System.Text.Json;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Swagger;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CustomerService.Features.Customer.SwaggerDocumentation
{
    public static class GetCustomersConfiguration
    {
        public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
        {
            // Configure the operation properties
            operation.OperationId = "Get all customers";
            operation.Summary = "Get all customers summary";
            operation.Description = "Get all customers description";

            // Configure the responses
            operation.Responses = ResponseInfo.GetResponsesInfo();
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
            {
                Example = new OpenApiString(
                    JsonSerializer.Serialize(new List<CustomerResponseDto>()
                    {
                        new(Guid.NewGuid(),"Firstname", "Lastname", "EmailAddress")
                    }))
            };

            return operation;
        }
    }
}