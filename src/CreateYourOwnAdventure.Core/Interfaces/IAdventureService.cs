using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Interfaces;

public interface IAdventureService
{
	public Task<int> Create(CreateAdventureRequest request);
	public Task<List<BinaryTree<Question>>> Get();
	public Task<BinaryTree<Question>?> Get(int id);
}