using Asp.Versioning;
using EventMatcha.WebApi.Middlewares;
using EventMatcha.Application;
using EventMatcha.Infrastructure;
using EventMatcha.Presentation;
using Serilog;
using System.Text.Json.Serialization;





namespace EventMatcha.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .Configuration
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}", true, true)
                .AddJsonFile("appsettings.local.json", true, true)
                .AddUserSecrets<Program>(true)
                .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddPresentation()
                .AddExceptionHandler<GlobalExceptionHandler>()
                .AddProblemDetails()
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        new UrlSegmentApiVersionReader(),
                        new HeaderApiVersionReader("X-Api-Version"));
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentation.DependencyInjection).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Convert Enums to string
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
