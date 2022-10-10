using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Services;

public class AdventureService : IAdventureService
{
	private readonly IRepository<BinaryTree<Question>> _adventureRepository;
	private readonly IRepository<Game?> _gameRepository;
	private readonly IBinaryTreeService _binaryTreeService;

	public AdventureService(IBinaryTreeService binaryTreeService, IRepository<BinaryTree<Question>> adventureRepository,
		IRepository<Game?> gameRepository)
	{
		_binaryTreeService = binaryTreeService;
		_adventureRepository = adventureRepository;
		_gameRepository = gameRepository;
	}
	
	public async Task<int> Create(CreateAdventureRequest request)
	{
		BinaryTree<Question> tree = _binaryTreeService.BuildTree(request);

		int result = await _adventureRepository.Create(tree);

		return result;
	}

	public async Task<List<BinaryTree<Question>>> Get()
	{
		List<BinaryTree<Question>> results = await _adventureRepository.Get();

		return results;
	}

	public async Task<BinaryTree<Question>?> Get(int id)
	{
		BinaryTree<Question>? result = await _adventureRepository.Get(id);

		return result;
	}
}