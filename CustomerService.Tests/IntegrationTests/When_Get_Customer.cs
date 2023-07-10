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
    public async Task Then_Customers_Should_Be_Returned_From_Db()
    {
        //Arrange
        var customer = ArrangeDbData();

        //Act
        var response = await HttpClient.GetAsync($"/api/v1/customers/{customer.Id}");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<CustomerResponseDto>();
        content.Should().Be(new CustomerResponseDto(customer.Id,
            customer.FirstName,
            customer.LastName,
            customer.EmailAddress)
        );
    }
}