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

    private readonly ILogger<PLayerController> _logger;
    private readonly IPlayerDataAccess _playerDataAccess;

    public PLayerController(ILogger<PLayerController> logger, IPlayerDataAccess playerDataAccess)
    {
        _logger = logger;
        _playerDataAccess = playerDataAccess;
    }

    [HttpPut]
    [Route("{id:int}/captain")]
    [ProducesResponseType(200)]
    [Produces("application/json")]
    public StatusCodeResult AddPlayerOnTeamByYear(int id)
    {
        if(id < 0)
        {
            return StatusCode(400);
        }
        else{
            _playerDataAccess.UpdatePlayerAsCaptain(id);
            return StatusCode(200);
        }
    }
}

