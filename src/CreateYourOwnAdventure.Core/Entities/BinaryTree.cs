using System.Text.Json.Serialization;

namespace CreateYourOwnAdventure.Core.Entities;

public record BinaryTree<T>
{
	[JsonPropertyName("adventureId")]
	public int BinaryTreeId { get; set; }
	public BinaryTreeNode<T>? Root { get; set; }
}