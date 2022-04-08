using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MontrealHockeyTeamAPI.DAL;
using MontrealHockeyTeamAPI.Interfaces;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
namespace MontrealHockeyTeamAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{

    private readonly ILogger<TeamController> _logger;
    private readonly IConfiguration _configuration;
    private readonly ITeamDataAccess _teamDataAccess;
    private readonly IPlayerDataAccess _playerDataAccess;

    public TeamController(ILogger<TeamController> logger, IConfiguration configuration, ITeamDataAccess teamDataAccess, IPlayerDataAccess playerDataAccess )
    {
        _logger = logger;
        _configuration = configuration;
        _teamDataAccess = teamDataAccess;
        _playerDataAccess = playerDataAccess;
    }

    [HttpGet]
    [Produces("application/json")]
    public List<Team> Get()
    {
        return _teamDataAccess.GetAllTeamsWithPlayers();
    }
    [HttpGet("{year:int}")]
    [Produces("application/json")]
    public Team GetTeamByYear(int year)
    {
        return _teamDataAccess.GetTeamByYearWithPlayers(year);
    }
    [HttpPost("{year:int}")]
    [ProducesResponseType(201)]
    [Produces("application/json")]
    public StatusCodeResult AddPlayerOnTeamByYear(int year, Player player)
    {
        _playerDataAccess.AddPlayerOnTeamByYear(year, player);
        return StatusCode(201);
    }
}

