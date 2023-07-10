using System.Net;
using System.Text;
using CustomerService.Features.Customer.DTOs.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Create_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Be_Added_To_Database()
    {
        //Arrange
        var expectedCustomer = new CustomerRequestDto("TestFirstname", "TestLastname", "test@test.sk", Gender.Male);


        //Act
        var res = await HttpClient.PostAsync("/api/v2/customers",
            new StringContent(JsonConvert.SerializeObject(expectedCustomer), Encoding.Default,
                "application/json"));

        //Assert
        res.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}