using Microsoft.OpenApi.Models;

namespace MinimalAPI.Swagger;

public static class ResponseInfo
{
    public static OpenApiResponses GetResponsesInfo()
    {
        return new OpenApiResponses(new OpenApiResponses()
        {
            ["200"] = new()
            {
                Description = "Success"
            },
            ["400"] = new()
            {
                Description = "Bad request"
            },
            ["404"] = new()
            {
                Description = "Not found"
            }
        });
    }
}