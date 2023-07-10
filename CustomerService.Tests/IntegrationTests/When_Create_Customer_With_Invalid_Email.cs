using System.Net;
using System.Text;
using CustomerService.Features.Customer.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CustomerService.Tests.IntegrationTests;

[TestClass]
public class When_Create_Customer_With_Invalid_Email : TestBase
{
    [TestMethod]
    public async Task Then_Validation_Error_Should_Be_Returned()
    {
        {
            // Arrange
            var invalidCustomer = new CustomerRequestDto("TestFirstname", "TestLastname", "test");

            //Act
            var response = await HttpClient.PostAsync("/api/v1/customers",
                new StringContent(JsonConvert.SerializeObject(invalidCustomer), Encoding.Default,
                    "application/json"));

            var content = await response.Content.ReadAsStringAsync();
            var validationProblemResult = JsonConvert.DeserializeObject<ValidationProblemDetails>(content);

            // Assert
            validationProblemResult.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            validationProblemResult!.Errors.Should().ContainKey("EmailAddress").And.Subject["EmailAddress"].Should()
                .BeEquivalentTo("Email address is invalid");
        }
    }
}