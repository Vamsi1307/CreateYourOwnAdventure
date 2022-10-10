using System.Text.Json.Serialization;

namespace CreateYourOwnAdventure.Core.Entities;

public record TreeNode<T>
{
	[JsonIgnore] 
	public List<TreeNode<T>>? Children { get; set; }

	public T? Data { get; set; }
}