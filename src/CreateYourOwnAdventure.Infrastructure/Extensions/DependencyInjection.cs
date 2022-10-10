using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Infrastructure.Contexts;
using CreateYourOwnAdventure.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CreateYourOwnAdventure.Infrastructure.Extensions;

public static class DependencyInjection
{
	public static void AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddDbContext<AdventureContext>();
		services.AddScoped<IRepository<BinaryTree<Question>>, AdventureRepository>();
		services.AddScoped<IRepository<Game>, GameRepository>();
	}
	
	public static void MigrateDatabase(this IApplicationBuilder app)
	{
		using IServiceScope scope = app.ApplicationServices.CreateScope();
		IServiceProvider services = scope.ServiceProvider;
		AdventureContext context = services.GetRequiredService<AdventureContext>();
		context.Database.Migrate();
	}
}