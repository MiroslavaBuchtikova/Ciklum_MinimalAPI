using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Features.Customer.DTOs;
using Customer = MinimalAPI.Core.Entities.Customer;

namespace MinimalAPI.Tests.UseCases;

[TestClass]
public class When_Delete_Customer : TestBase
{
    [TestMethod]
    public async Task Then_Customer_Should_Have_Valid_Response()
    {
        //Arrange
        var id = ArrangeDbData();
        
        var client = CreateCustomerClient();
        var response = await client.DeleteAsync($"/v1/customers/763bba5b-2f75-40b8-8b0b-2b43bd53f23f?api-version=1.0");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ResultDto>();
        content.Should().Be(new ResultDto ( id ));
    }

    private Guid ArrangeDbData()
    {
        using (var context = GetDbContext(DbContextOptions))
        {
            var customer = context.Customers.Add(new Customer
            {
                Id = new Guid("763bba5b-2f75-40b8-8b0b-2b43bd53f23f"),
                FirstName = "test",
                LastName = "test",
                EmailAddress = "test"
            }).Entity;

            context.SaveChanges();

            return customer.Id;
        }
    }
}