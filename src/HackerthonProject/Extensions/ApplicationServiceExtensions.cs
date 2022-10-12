using HackerthonProject.Data;
using HackerthonProject.Repositories.Abstraction;
using HackerthonProject.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace HackerthonProject.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<IAdvocateRepository, AdvocateRepository>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                x.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://example.com");
                });
            });

            return services;
        }
    }
}
