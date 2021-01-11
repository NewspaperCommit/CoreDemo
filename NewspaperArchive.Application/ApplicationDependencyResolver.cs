using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
//using Newspaper.Application.Services;
//using Microsoft.AspNetCore.Builder;
using NewspaperArchive.Application.Behaviour;
//using Newspaper.Application.Mapping.MappingUser;
using NewspaperArchive.Application.Common.API;

namespace NewspaperArchive.Application
{



    public static class ApplicationDependencyResolver
    {
        public static IServiceCollection ServiceResolver(this IServiceCollection services)
        {
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingUserConfiguration());

            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            return services;
        }
    }

    public static class MiddlewareExtensions
    {
        public static void AddBehaviour(this IApplicationBuilder builder, ApiResponseOptions options = default)
        {
            
            
            builder.UseMiddleware<PerformanceMiddleware>();
            builder.UseMiddleware<LoggingMiddleware>();
            builder.UseMiddleware<ValidationMiddleware>();
            builder.UseMiddleware<ExceptionMiddleware>();
           // builder.UseMiddleware<ApiResponseMiddleware>();

        }
    }

   



}
