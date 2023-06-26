using CustomerService.Swagger;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace CustomerService.Features.Authorization.SwaggerDocumentation
{
    public static class GetAuthorizationTokenConfiguration
    {
        public static OpenApiOperation ConfigureOpenApiOperation(OpenApiOperation operation)
        {
            // Configure the operation properties
            operation.OperationId = "GetCustomerHandler Authorization Token";
            operation.Summary = "GetCustomerHandler Authorization Token summary";
            operation.Description = "GetCustomerHandler authorization token description";

            // Configure the responses
            operation.Responses = ResponseInfo.GetResponsesInfo();
            operation.Responses["200"].Content["application/json"] = new OpenApiMediaType()
            {
                Example = new OpenApiString(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")
            };

            return operation;
        }
    }
}