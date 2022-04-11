using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MontrealHockeyTeamAPI.Controllers;
using MontrealHockeyTeamAPI.Interfaces.implements;
using Moq;
using Xunit;

namespace MontrealHockeyTeamAPI.Tests;

public class PlayerControllerTests
{
    [Fact]
    public void AddPlayerOnTeamByYear_BadReuest_If_Id_IsNegative()
    {
        //Arrange
        var logger = Mock.Of<ILogger<PLayerController>>();
        var playerDataStore = A.Fake<IPlayerDataAccess>();
        PLayerController? controller = new PLayerController(logger, playerDataStore);
        //Act
        StatusCodeResult actionresult = controller.AddPlayerOnTeamByYear(-1);
        //Assert
        Assert.Equal(400, actionresult.StatusCode);
    }
}
