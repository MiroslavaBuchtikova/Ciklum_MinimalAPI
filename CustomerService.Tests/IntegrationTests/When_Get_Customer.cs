using System.Net;
using System.Net.Http.Json;
using CustomerService.Features.Customer.DTOs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerService.Tests.IntegrationTests;

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
        var response = await client.GetAsync($"/api/v1/customers/{customer.Id}");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<CustomerDto>();
        content.Should().Be(new CustomerDto(
            customer.FirstName,
            customer.LastName,
            customer.EmailAddress)
        );
    }
}