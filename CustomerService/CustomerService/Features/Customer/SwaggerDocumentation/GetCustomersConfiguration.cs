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