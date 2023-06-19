using System.Net;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Application.Features.Customer.DomainModels;
using Newtonsoft.Json;

namespace MinimalAPI.Tests.UseCases;

[TestClass]
public class When_Delete_Customer
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        var client = new TestBase().CreateCustomerClient();
        var res = await client.PostAsync("/v1/customers?api-version=1.0",
            new StringContent(JsonConvert.SerializeObject(new Customer()
                {
                    FirstName = "test",
                    LastName = "test",
                    EmailAddress = "test@test.sk"
                }), Encoding.Default,
                "application/json"));

        res.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}