using System.Net;
using System.Net.Http.Json;
using CustomerService.Features.Customer.DTOs.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Get_All_Customers : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var customer = ArrangeDbData();

        //Act
        var client = CreateCustomerClient();
        var response = await client.GetAsync($"/api/v2/customers");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<List<CustomerResponseDto>>();
        content.Should().Equal(new List<CustomerResponseDto>()
        {
            new(customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.EmailAddress,
                (Gender)customer.Gender
            )
        });
    }
}