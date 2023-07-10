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
    public async Task Then_Customer_Should_Be_Edited_In_Db()
    {
        //Arrange
        var customer = ArrangeDbData();
        var updatedCustomer = new CustomerResponseDto(Guid.NewGuid(),"firstname_updated", "lastname_updated", "email@email_updated.sk");

        //Act
        var response = await HttpClient.PutAsync($"/api/v1/customers/{customer.Id}", new StringContent(
            JsonConvert.SerializeObject(updatedCustomer), Encoding.Default,
            "application/json"));

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ResultDto>();
        content.Should().Be(new ResultDto ( customer.Id ));
    }
}