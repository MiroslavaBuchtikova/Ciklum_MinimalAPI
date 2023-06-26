using System.Net;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Features.Customer.DTOs;
using Newtonsoft.Json;

namespace MinimalAPI.Tests.UseCases;

[TestClass]
public class When_Create_Customer
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        var client = new TestBase().CreateCustomerClient();
        var res = await client.PostAsync("/v1/customers",
            new StringContent(JsonConvert.SerializeObject(new CustomerDto("test", "test", "test@test.sk")), Encoding.Default,
                "application/json"));

        res.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}