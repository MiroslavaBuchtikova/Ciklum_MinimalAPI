using System.Net;
using System.Net.Http.Json;
using System.Text;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Features.Customer.DTOs.v2;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using CustomerRequestDto = CustomerService.Features.Customer.DTOs.v2.CustomerRequestDto;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Update_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Be_Edited_In_Db()
    {
        //Arrange
        var customer = ArrangeDbData();
        var updatedCustomerDto = new CustomerRequestDto("firstname_updated", "lastname_updated", "email@email_updated.sk", Gender.Female);

        //Act
        var response = await HttpClient.PutAsync($"/api/v2/customers/{customer.Id}", new StringContent(
            JsonConvert.SerializeObject(updatedCustomerDto), Encoding.Default,
            "application/json"));

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ResultDto>();
        content.Should().Be(new ResultDto ( customer.Id ));
    }
}