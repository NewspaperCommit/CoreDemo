using System;
using Microsoft.Extensions.DependencyInjection;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Services;
using NewspaperArchive.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Helper;

namespace NewspaperArchive.Infrastructure
{
    public static class InfrastructureDependencyResolver
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            //services.AddScoped<IParameterManager, IParameterManager>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseSqlServer(
            //     configuration.GetConnectionString("SiteInfoConnectionString"),
            //     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<SiteInfoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SiteInfoConnectionString")));
            services.AddDbContext<PaymentInformationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PaymentInformationConnectionString")));
            services.AddDbContext<DemoDbContext>(optionns => optionns.UseSqlServer(configuration.GetConnectionString("DemoConnectionString")));
            services.AddScoped<IService, Service>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IEvent, Event>();
            //services.AddScoped<IJwt, JWTServices>();
            services.AddScoped<IContextDataHandler, CommonDataHandler>();
            services.AddScoped<IHeaderLink, HeaderLinkService>();
            services.AddScoped<IShoppingCart, ShoppingCartServices>();
            //services.AddScoped<IShoppingCart, ShoppingCartNavigation>();
            services.AddSingleton<ILoggerService, LogService>();
            services.AddScoped<ICountryService, CountryServices>();
            services.AddScoped<ILoginServices,LoginServices>();
            //services.AddScoped<GetItemCount, LoginServices>();


            services.AddScoped(typeof(IAutoMapConverter<,>), typeof(AutoMapConverter<,>));

        }
    }
    
}
