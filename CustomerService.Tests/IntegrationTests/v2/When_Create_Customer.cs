using System.Net;
using System.Text;
using CustomerService.Features.Customer.DTOs.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using CustomerDto = CustomerService.Features.Customer.DTOs.v2.CustomerDto;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Create_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var client = new TestBase().CreateCustomerClient();
        
        //Act
        var res = await client.PostAsync("/api/v2/customers",
            new StringContent(JsonConvert.SerializeObject(new CustomerDto("test", "test", "test@test.sk", Gender.Male)), Encoding.Default,
                "application/json"));

        //Assert
        res.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}