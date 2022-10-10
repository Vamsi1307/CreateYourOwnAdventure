using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CreateYourOwnAdventure.Infrastructure.Repositories;

public class GameRepository : IRepository<Game>
{
	private readonly AdventureContext _adventureContext;
	private readonly ILogger<AdventureRepository> _logger;

	public GameRepository(ILogger<AdventureRepository> logger, AdventureContext adventureContext)
	{
		_logger = logger;
		_adventureContext = adventureContext;
	}

	public async Task<int> Create(Game game)
	{
		await _adventureContext.MyAdventures.AddAsync(game);

		int result = await _adventureContext.SaveChangesAsync();

		return result;
	}

	public async Task<Game?> Get(int id)
	{
		Game? game = await _adventureContext.MyAdventures.Where(x => x.MyAdventureId == id).FirstOrDefaultAsync();

		return game;
	}

	public async Task<List<Game>> Get()
	{
		List<Game> games = await _adventureContext.MyAdventures.ToListAsync();

		return games;
	}
}