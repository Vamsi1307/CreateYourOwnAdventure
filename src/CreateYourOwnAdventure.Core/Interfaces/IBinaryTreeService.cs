using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Interfaces;

public interface IBinaryTreeService
{
	public BinaryTree<Question> BuildTree(CreateAdventureRequest request);
	public List<GameResponse> Get(BinaryTree<Question> tree, List<char> steps);
}