using HackerthonProject.Core;
using HackerthonProject.Data;
using HackerthonProject.Features.Handlers.Queries;
using HackerthonProject.Repositories.Abstraction;
using HackerthonProject.Repositories.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HackerthonProject.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<IAdvocateRepository, AdvocateRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false)
       .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     _config.GetConnectionString("DatabaseConnection")));

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://example.com");
                });
            });

            services.AddMediatR(typeof(GetAllCompaniesRequestHandler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
