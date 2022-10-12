using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreateYourOwnAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class GameController : ControllerBase
{
	private readonly IGameService _gameService;
	private readonly ILogger<GameController> _logger;

	public GameController(ILogger<GameController> logger, IGameService gameService)
	{
		_logger = logger;
		_gameService = gameService;
	}

	[HttpGet("{gameId:int}")]
	public async Task<IActionResult> Get(int gameId)
	{
		try
		{
            var results = await _gameService.Get(gameId);

            return Ok(results);
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error occurred in Get(gameId) API.");
            throw;
		}        
    }
	
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
            List<Game?> results = await _gameService.Get();

            return Ok(results);
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error occurred in Get() API.");
            throw;
		}		
	}

	[HttpPost]
	public async Task<IActionResult> Create(int adventureId, List<char> steps)
	{
		try
		{
            int result = await _gameService.Create(adventureId, steps);

            return result == 1 ? Ok() : Problem();
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error occurred in Create(adventureId, steps) API.");
            throw;
		}		
	}
}