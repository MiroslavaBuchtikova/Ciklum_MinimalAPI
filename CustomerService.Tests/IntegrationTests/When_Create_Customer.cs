using System.Net;
using System.Text;
using CustomerService.Features.Customer.DTOs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CustomerService.Tests.IntegrationTests;

[TestClass]
public class When_Create_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var client = new TestBase().CreateCustomerClient();
        
        //Act
        var res = await client.PostAsync("/api/v1/customers",
            new StringContent(JsonConvert.SerializeObject(new CustomerDto("test", "test", "test@test.sk")), Encoding.Default,
                "application/json"));

        //Assert
        res.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}