using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;

namespace CreateYourOwnAdventure.Core.Services;

public class BinaryTreeService : IBinaryTreeService
{
	public BinaryTree<Question> BuildTree(CreateAdventureRequest request)
	{
		BinaryTree<Question> tree = new();

		if (string.IsNullOrWhiteSpace(request?.Question)) return tree;

		tree.Root = new BinaryTreeNode<Question>
		{
			Data = new Question(request.Question)
		};

		BuildLeaf(tree.Root, request);

		return tree;
	}

	public List<GameResponse> Get(BinaryTree<Question> tree, List<char> steps)
	{
		List<GameResponse> games = new();

		if (tree == null || steps == null) return games;

		BinaryTreeNode<Question>? root = tree?.Root;

		foreach (char step in steps)
		{
			games.Add(new GameResponse
			{
				MyAdventure = step,
				Question = root?.Data?.Text
			});

			root = step switch
			{
				'Y' => root?.Yes,
				'N' => root?.No,
				_ => root
			};
		}

		return games;
	}

	private void BuildLeaf(BinaryTreeNode<Question>? root, CreateAdventureRequest? request)
	{
		if (root == null)
		{
			return;
		}

		if (!string.IsNullOrWhiteSpace(request?.Yes?.Question))
		{
			root.Yes ??= new BinaryTreeNode<Question>
			{
				Data = new Question(request.Yes.Question)
			};
			BuildLeaf(root.Yes, request.Yes);
		}

		if (!string.IsNullOrWhiteSpace(request?.No?.Question))
		{
			root.No ??= new BinaryTreeNode<Question>
			{
				Data = new Question(request.No.Question)
			};
			BuildLeaf(root.No, request.No);
		}
	}
}