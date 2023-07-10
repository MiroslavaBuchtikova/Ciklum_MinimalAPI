using System.Net;
using System.Text;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Features.Customer.DTOs.v2;
using CustomerService.Middlewares;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using CustomerRequestDto = CustomerService.Features.Customer.DTOs.v2.CustomerRequestDto;

namespace CustomerService.Tests.IntegrationTests.v2;

[TestClass]
public class When_Update_Customer_Who_Doesnt_Exists : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Be_Edited_In_Db()
    {
        //Arrange
        var updatedCustomer = new CustomerRequestDto("firstname_updated", "lastname_updated",
            "email@email_updated.sk", Gender.Female);

        //Act
        var response = await
            HttpClient.PutAsync($"/api/v2/customers/{Guid.NewGuid()}", new StringContent(
                JsonConvert.SerializeObject(updatedCustomer), Encoding.Default,
                "application/json"));
        
        var content = await response.Content.ReadAsStringAsync();
        var exceptionResult = JsonConvert.DeserializeObject<ErrorResponse>(content);
        
        //Assert
        exceptionResult!.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        exceptionResult.Message.Should().Be("Customer with given id doesn't exist");
    }
}