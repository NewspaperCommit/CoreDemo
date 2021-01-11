using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewspaperArchive.Application;
using NewspaperArchive.Application.Behaviour;
using NewspaperArchive.Filters;
using FluentValidation.AspNetCore;
using NewspaperArchive.Infrastructure.Services;
using NewspaperArchive.Infrastructure;

using Microsoft.Extensions.Configuration;

namespace NewspaperArchive
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContextPool<SiteInfoDbContext>
            services.AddInfrastructure(_config);
            //services.AddControllersWithViews(options =>
            //     options.Filters.Add(new ApplicationExceptionFilterAttribute()))
            //         .AddFluentValidation();
            services.AddRazorPages();
            //  services.AutoMapperServiceResolver();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
           // app.AddBehaviour();
            // app.AddLogginBehaviour();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home2}/{action=Index}/{id?}");
            //});



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

        }
    }
}
