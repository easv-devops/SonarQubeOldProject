using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using infrastructure.Data.Repository;
using Service;

namespace api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
                services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
                dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

                services.AddSingleton<UserRepository>();
                services.AddSingleton<UserService>();

                services.AddSingleton<CourseRepository>();
                services.AddSingleton<CourseService>();

                services.AddSingleton<AvatarImageRepository>();
                services.AddSingleton<AvatarImageService>();

                services.AddSingleton<CourseEnrollRepository>();
                services.AddSingleton<CourseEnrollService>();


                services.AddSingleton<CourseLevelService>();
                services.AddSingleton<CourseLevelRepository>();

                services.AddSingleton<ResourcesService>();
                services.AddSingleton<ResourcesRepository>();

                services.AddControllers();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();

                return services;
        }
        
    }
}