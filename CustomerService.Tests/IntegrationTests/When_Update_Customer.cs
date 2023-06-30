using System.Net;
using System.Net.Http.Json;
using System.Text;
using CustomerService.Features.Customer.DTOs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CustomerService.Tests.IntegrationTests;

[TestClass]
public class When_Update_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var customer = ArrangeDbData();
        var updatedCustomerDto = new CustomerResponseDto(Guid.NewGuid(),"firstname_updated", "lastname_updated", "email@email_updated.sk");

        //Act
        var client = CreateCustomerClient();
        var response = await client.PutAsync($"/api/v1/customers/{customer.Id}", new StringContent(
            JsonConvert.SerializeObject(updatedCustomerDto), Encoding.Default,
            "application/json"));

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ResultDto>();
        content.Should().Be(new ResultDto ( customer.Id ));
    }
}