using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Interfaces;

public interface IGameService
{
	public Task<int> Create(int adventureId, List<char> steps);
	public Task<List<Game?>> Get();
	public Task<List<GameResponse>> Get(int id);
}