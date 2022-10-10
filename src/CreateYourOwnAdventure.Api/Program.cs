using System.Text.Json.Serialization;
using CreateYourOwnAdventure.Core.Extensions;
using CreateYourOwnAdventure.Infrastructure.Extensions;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Logging

builder.Logging.AddApplicationInsights(builder.Configuration["APPINSIGHTS_INSTRUMENTATION_KEY"] ?? string.Empty);
builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(typeof(Program).FullName, LogLevel.Trace);
builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(string.Empty, LogLevel.Information);
builder.Services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
{
	EnableAdaptiveSampling = false,
	DeveloperMode = true
});

#endregion

builder.Services.AddControllers().AddJsonOptions(option =>
{
	option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1",
	new OpenApiInfo { Title = "Create Your Own Adventure" }));

builder.Services.AddHttpContextAccessor();
builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();

WebApplication app = builder.Build();

//if (!app.Environment.IsProduction())
//{
	app.UseSwagger();
	app.UseSwaggerUI(x =>
	{
		x.SwaggerEndpoint("/swagger/v1/swagger.json", "Create Your Own Adventure");
		x.RoutePrefix = string.Empty;
		x.DefaultModelsExpandDepth(-1);
	});
	app.MigrateDatabase();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();