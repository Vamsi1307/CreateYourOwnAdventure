namespace CreateYourOwnAdventure.Core.Entities;

public record Question(string Text)
{
	public string Text { get; set; } = Text;
}