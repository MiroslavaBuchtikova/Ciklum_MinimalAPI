using System.Net;
using System.Net.Http.Json;
using CustomerService.Features.Customer.DTOs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Delete_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Be_Removed_From_Db()
    {
        //Arrange
        var customer = ArrangeDbData();
        
        //Act
        var response = await HttpClient.DeleteAsync($"/api/v2/customers/{customer.Id}");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ResultDto>();
        content.Should().Be(new ResultDto ( customer.Id ));
    }
}