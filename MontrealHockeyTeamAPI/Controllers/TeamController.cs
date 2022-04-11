﻿using Microsoft.AspNetCore.Cors;
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
    private readonly ITeamDataAccess _teamDataAccess;
    private readonly IPlayerDataAccess _playerDataAccess;

    public TeamController(ILogger<TeamController> logger, ITeamDataAccess teamDataAccess, IPlayerDataAccess playerDataAccess )
    {
        _logger = logger;
        _teamDataAccess = teamDataAccess;
        _playerDataAccess = playerDataAccess;
    }

    [HttpGet("{year:int}")]
    [Produces("application/json")]
    public ActionResult GetTeamByYear(int year)
    {

        return StatusCode(200, _teamDataAccess.GetTeamByYearWithPlayers(year));

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

