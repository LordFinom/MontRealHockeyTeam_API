using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MontrealHockeyTeamAPI.DAL;
using MontrealHockeyTeamAPI.Interfaces;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
namespace MontrealHockeyTeamAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PLayerController : ControllerBase
{

    private readonly ILogger<TeamController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IPlayerDataAccess _playerDataAccess;

    public PLayerController(ILogger<TeamController> logger, IConfiguration configuration, IPlayerDataAccess playerDataAccess)
    {
        _logger = logger;
        _configuration = configuration;
        _playerDataAccess = playerDataAccess;
    }

    [HttpPut]
    [Route("{id:int}/captain")]
    [ProducesResponseType(200)]
    [Produces("application/json")]
    public StatusCodeResult AddPlayerOnTeamByYear(int id)
    {
        _playerDataAccess.UpdatePlayerAsCaptain(id);
        return StatusCode(200);
    }
}

