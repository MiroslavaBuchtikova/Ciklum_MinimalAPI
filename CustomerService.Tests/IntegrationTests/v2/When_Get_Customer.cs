using System.Net;
using System.Net.Http.Json;
using CustomerService.Features.Customer.DTOs.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Get_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var customer = ArrangeDbData();

        //Act
        var client = CreateCustomerClient();
        var response = await client.GetAsync($"/api/v2/customers/{customer.Id}");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Features.Customer.DTOs.v2.CustomerDto>();
        content.Should().Be(new Features.Customer.DTOs.v2.CustomerDto(
            customer.FirstName,
            customer.LastName,
            customer.EmailAddress,
            (Gender)customer.Gender)
        );
    }
}