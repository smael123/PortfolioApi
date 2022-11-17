using AutoMapper;
using Microsoft.Extensions.Logging.AzureAppServices;
using PortfolioApi.Persistence;

namespace PortfolioApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        CosmosConfig cosmosConfig;

        if (builder.Environment.EnvironmentName == "Production")
        {
            //get cosmos configuration from App Service Environment variables
            string? endpoint = Environment.GetEnvironmentVariable("PORTFOLIO_COSMOS_ENDPOINT");
            string? authKey = Environment.GetEnvironmentVariable("PORTFOLIO_COSMOS_KEY");
            string? databaseId = Environment.GetEnvironmentVariable("PORTFOLIO_COSMOS_DB");

            cosmosConfig = new(
                endpoint,
                authKey,
                databaseId
            );

            //set up logging
            builder.Logging.AddAzureWebAppDiagnostics();
            builder.Services.Configure<AzureFileLoggerOptions>(options =>
            {
                options.FileName = "azure-diagnostics-";
                options.FileSizeLimit = 50 * 1024; //5MB
                options.RetainedFileCountLimit = 5;
            });
            builder.Services.Configure<AzureBlobLoggerOptions>(options =>
            {
                options.BlobName = "log.txt";
            });
        }
        else
        {
            cosmosConfig = new(
                builder.Configuration["Cosmos:Endpoint"],
                builder.Configuration["Cosmos:AuthKey"],
                builder.Configuration["Cosmos:DatabaseId"]
            );
        }

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(cosmosConfig));

        builder.Services.AddAutoMapper(typeof(DefaultAutoMapperProfile));

        builder.Services.AddResponseCaching();

        var app = builder.Build();

        app.UseSwagger();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
        }

        //automatically add the cache headers to anonymous authorization GET 200 responses
        app.UseResponseCaching();
        app.Use(async (context, next) =>
        {
            context.Response.GetTypedHeaders().CacheControl =
                new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromDays(1) //browser will recache every day
                };

            context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                new string[] { "Accept-Encoding" };

            await next();
        });

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

