namespace CreateYourOwnAdventure.Core.Entities;

public class Game
{
	public int MyAdventureId { get; set; }
	public int BinaryTreeId { get; set; }
	public List<char> Steps { get; set; }
}