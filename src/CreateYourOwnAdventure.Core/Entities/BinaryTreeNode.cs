namespace CreateYourOwnAdventure.Core.Entities;

public record BinaryTreeNode<T> : TreeNode<T>
{
	public BinaryTreeNode() => Children = new List<TreeNode<T>>();

	public BinaryTreeNode<T>? Yes
	{
		get
		{
			if (Children?.Count > 0) return (BinaryTreeNode<T>)Children[0];
			return null;
		}
		set
		{
			if (value == null) return;
			Children?.Insert(0, value);
		}
	}

	public BinaryTreeNode<T>? No
	{
		get
		{
			if (Children?.Count > 1) return (BinaryTreeNode<T>)Children[1];
			return null;
		}
		set
		{
			if (value == null) return;
			Children.Insert(1, value);
		}
	}
}