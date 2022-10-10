using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CreateYourOwnAdventure.Core.Extensions;

public static class DependencyInjection
{
	public static void AddCoreServices(this IServiceCollection services)
	{
		services
			.AddScoped<IAdventureService, AdventureService>()
			.AddScoped<IGameService, GameService>()
			.AddScoped<IBinaryTreeService, BinaryTreeService>();
	}
}