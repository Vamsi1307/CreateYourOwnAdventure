using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreateYourOwnAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AdventureController : ControllerBase
{
	private readonly IAdventureService _adventureService;
	private readonly ILogger<AdventureController> _logger;

	public AdventureController(ILogger<AdventureController> logger, IAdventureService adventureService)
	{
		_logger = logger;
		_adventureService = adventureService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
            List<BinaryTree<Question>> results = await _adventureService.Get();
            return Ok(results);
        }
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error occurred in Get() API.");
			throw;
		}
	}
	
	[HttpGet("{adventureId:int}")]
	public async Task<IActionResult> Get(int adventureId)
	{
		try
		{
            BinaryTree<Question>? result = await _adventureService.Get(adventureId);

            return result == null ? NotFound() : Ok(result);
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error occurred in Get(adventureId) API.");
            throw;
        }		
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateAdventureRequest request)
	{
		try
		{
            int result = await _adventureService.Create(request);

            return result == 1 ? NoContent() : Problem();
        }
		catch (Exception ex)
		{
            _logger.LogError(ex, "Error occurred in Get(adventureId) API.");
            throw;
		}		
	}
}