using CloudCustomer.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomer.UnitTests;

public class UnitTest1
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Given
        var su = new UserController();
        var result = (OkObjectResult) await su.Get();
        result.StatusCode.Should().Be(200);

        // When

        // Then
    }
}