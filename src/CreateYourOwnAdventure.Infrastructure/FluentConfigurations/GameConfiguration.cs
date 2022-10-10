using System.Text.Json;
using System.Text.Json.Serialization;
using CreateYourOwnAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateYourOwnAdventure.Infrastructure.FluentConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
	public void Configure(EntityTypeBuilder<Game> builder)
	{
		JsonSerializerOptions options = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};

		builder.HasKey(x => x.MyAdventureId);

		builder.Property(x => x.MyAdventureId).ValueGeneratedOnAdd();

		builder.Property(x => x.Steps).HasConversion(
			y => JsonSerializer.Serialize(y, options),
			y => JsonSerializer.Deserialize<List<char>>(y, options));

		builder.HasData(new Game
		{
			BinaryTreeId = 1,
			MyAdventureId = 1,
			Steps = new List<char>
			{
				'Y', 'Y', 'N', 'Y'
			}
		});
	}
}