using Application.Services.ContactService;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();

            services.AddScoped<GetContactsList>();
            services.AddScoped<UploadCsvFile>();
            services.AddScoped<EditContact>();
            services.AddScoped<FindContact>();
            services.AddScoped<DeleteContact>();
            return services;
        }
    }
}