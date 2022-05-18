using CloudCustomer.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomer.UnitTests;

public class TestUserController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mokuserservice = new Mock<IUserService>();
        mokuserservice
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());
        var su = new UserController(mokuserservice.Object);
        var results = await su.Get();
        var res = (OkObjectResult)results;
        res.StatusCode.Should().Be(200);
        // When        // Then
    }

    [Fact]
    public async Task Get_OnSuccess_UserServiceInvoked()
    {
        var mokuserservice = new Mock<IUserService>();
        mokuserservice.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
        var sut = new UserController(mokuserservice.Object);
        var result = await sut.Get();
        mokuserservice.Verify(service => service.GetAllUsers(), Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_shouldReturnAlistOfUsers()
    {
        var mokuserservice = new Mock<IUserService>();
        mokuserservice
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());
        var sut = new UserController(mokuserservice.Object);
        var result = (OkObjectResult)await sut.Get();
        result.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUserFound_retuns404()
    {
        var mokuserservice = new Mock<IUserService>();
        mokuserservice.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
        var sut = new UserController(mokuserservice.Object);
        var result = await sut.Get();
        var objResult = (NotFoundResult)result;
        result.Should().BeOfType<NotFoundResult>();
        objResult.StatusCode.Should().Be(404);
    }
}
