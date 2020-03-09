using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .WithOrigins("http://localhost:4434", "http://localhost:4200", "http://localhost:44338")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}

//