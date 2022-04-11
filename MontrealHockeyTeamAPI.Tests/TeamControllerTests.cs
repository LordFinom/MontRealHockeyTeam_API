using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MontrealHockeyTeamAPI.Controllers;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
using Moq;
using Xunit;

namespace MontrealHockeyTeamAPI.Tests;

public class TeamControllerTests
{
    [Fact]
    public void GetTeamByYear_Returns_404_IfYearNotBetween2010and2021()
    {
        //Arrange
        var logger = Mock.Of<ILogger<TeamController>>();
        var teamDataStore = A.Fake<ITeamDataAccess>();
        var playerDataStore = A.Fake<IPlayerDataAccess>();
        TeamController? controller = new TeamController(logger, teamDataStore, playerDataStore);
        //Act
        var actionresult = controller.GetTeamByYear(2009) as StatusCodeResult;
        //Assert
        Assert.NotNull(actionresult);
        Assert.Equal(404, actionresult.StatusCode);
    }
}
