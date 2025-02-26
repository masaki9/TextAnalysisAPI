using TextAnalysisAPI.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TextAnalysisAPI;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure the server to listen on specific ports
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ListenLocalhost(5198); // Set HTTP port
            serverOptions.ListenLocalhost(7193, listenOptions =>
            {
                listenOptions.UseHttps(); // Set HTTPS port
            });
        });

        builder.Services.AddScoped<ITextAnalysisService, TextAnalysisService>(); // Register TextAnalysisService
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        // Register the Swagger generator for API documentation
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Text Analysis API", Version = "v1" });

            // Include the XML comments in the API documentation in Swagger
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // Enable Swagger for API documentation
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
