using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CreateYourOwnAdventure.Infrastructure.Repositories;

public class AdventureRepository : IRepository<BinaryTree<Question>>
{
	private readonly AdventureContext _adventureContext;
	private readonly ILogger<AdventureRepository> _logger;

	public AdventureRepository(ILogger<AdventureRepository> logger, AdventureContext adventureContext)
	{
		_logger = logger;
		_adventureContext = adventureContext;
	}

	public async Task<int> Create(BinaryTree<Question> tree)
	{
		await _adventureContext.Adventures.AddAsync(tree);
		int result = await _adventureContext.SaveChangesAsync();

		return result;
	}

	public async Task<BinaryTree<Question>?> Get(int id)
	{
		BinaryTree<Question>? tree =
			await _adventureContext.Adventures.Where(x => x.BinaryTreeId == id).FirstOrDefaultAsync();

		return tree;
	}

	public async Task<List<BinaryTree<Question>>> Get()
	{
		List<BinaryTree<Question>> trees = await _adventureContext.Adventures.ToListAsync();

		return trees;
	}
}