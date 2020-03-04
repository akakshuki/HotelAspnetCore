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
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}

//.WithOrigins("http://localhost:4434", "http://localhost:4200/", "http://localhost:64906")