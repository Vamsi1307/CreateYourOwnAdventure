using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Services;

public class GameService: IGameService
{
	private readonly IRepository<BinaryTree<Question>> _adventureRepository;
	private readonly IRepository<Game?> _gameRepository;
	private readonly IBinaryTreeService _binaryTreeService;

	public GameService(IBinaryTreeService binaryTreeService, IRepository<BinaryTree<Question>> adventureRepository,
		IRepository<Game?> gameRepository)
	{
		_binaryTreeService = binaryTreeService;
		_adventureRepository = adventureRepository;
		_gameRepository = gameRepository;
	}
	
	public async Task<GameTraverse?> Get(int gameId)
	{
		Game? game = await _gameRepository.Get(gameId);

		if (game == null) return null;

		BinaryTree<Question>? tree = await _adventureRepository.Get(game.BinaryTreeId);

		if (tree == null) return null;

		List<GameResponse> path = _binaryTreeService.Get(tree, game.Steps);

		return new GameTraverse() { 
			GameId = gameId,
			Choices = path
		};
	}

	public async Task<List<Game?>> Get()
	{
		List<Game?> result = await _gameRepository.Get();

		return result;
	}

	public async Task<int> Create(int adventureId, List<char> steps)
	{
        BinaryTree<Question>? adventureResult = await _adventureRepository.Get(adventureId);
		if (adventureResult == null) return 0;

        int result = await _gameRepository.Create(new Game
		{
			Steps = steps,
			BinaryTreeId = adventureId
		});

		return result;
	}
}