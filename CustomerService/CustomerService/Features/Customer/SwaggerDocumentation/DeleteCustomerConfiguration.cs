using CustomerService.Swagger;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CustomerService.Features.Customer.SwaggerDocumentation
{
    public static class DeleteCustomerConfiguration
    {
        public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
        {
            // Configure the operation properties
            operation.OperationId = "Delete customer";
            operation.Summary = "Delete customer summary";
            operation.Description = "Delete customer description";

            // Configure the request parameter
            var openApiRequestBody = operation.Parameters[0];
            openApiRequestBody.Description = "Request body description";
            openApiRequestBody.Example = new OpenApiString(Guid.NewGuid().ToString());

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