using EventMatcha.Infrastructure.Data;
using EventMatcha.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using EventMatcha.Domain.Fotos;
using EventMatcha.Infrastructure.Repositories;
using EventMatcha.Domain.Testimonials;
using EventMatcha.Domain.FAQs;



namespace EventMatcha.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureOptions<TOption>(this IServiceCollection services,
            IConfiguration configuration) where TOption : class, new()
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configuration);

            var option = new TOption();
            configuration.Bind(option);
            services.AddSingleton(option);

            return services;
        }

        private static void SetupOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<MongoDbOptions>(configuration.GetSection(MongoDbOptions.Section));
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            SetupOptions(services, configuration);

            services.AddHttpClient();

            ConventionRegistry.Register("Camel Case", new ConventionPack { new CamelCaseElementNameConvention() }, _ => true);

            services.AddScoped<DataContext>();
            services.AddScoped<IFotoRepository, FotoRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IFaqsRepository, FaqsRepository>();

            return services;
        }
    }
}
