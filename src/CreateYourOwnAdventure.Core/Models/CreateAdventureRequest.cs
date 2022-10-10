namespace CreateYourOwnAdventure.Core.Models;

public record CreateAdventureRequest
{
	public string? Question { get; set; }
	public CreateAdventureRequest? Yes { get; set; }
	public CreateAdventureRequest? No { get; set; }
}