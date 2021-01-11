using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Services;
using NewspaperArchive.Infrastructure;
using NewspaperArchive.Application.Model;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DemoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddJsonOptions(options => {
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            //});
            services.AddControllers().AddNewtonsoftJson();

            

            services.AddCors(
            options => options.AddPolicy("AllowCors",
            builder => {
                builder
                //.WithOrigins("http://localhost:4456") //AllowSpecificOrigins;
                //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;
                .AllowAnyOrigin() //AllowAllOrigins;
                                  //.WithMethods("GET") //AllowSpecificMethods;
                                  //.WithMethods("GET", "PUT") //AllowSpecificMethods;
                                  //.WithMethods("GET", "PUT", "POST") //AllowSpecificMethods;
                .WithMethods("GET", "PUT", "POST", "DELETE") //AllowSpecificMethods;
                                                             //.AllowAnyMethod() //AllowAllMethods;
                                                             //.WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header"); //AllowSpecificHeaders;
                .AllowAnyHeader(); //AllowAllHeaders;
            })
            );
            //services.AddCors();
            //services.AddDbContext<DemoDbContext>(optionns =>
            //    optionns.UseSqlServer(Configuration.GetConnectionString("DemoConnectionString")));

            //var jwtTokenConfig = Configuration.GetSection("JwtToken").Get<JwtToken>();
            //services.AddSingleton(jwtTokenConfig);
            //var appSettingSection = Configuration.GetSection("JwtToken");
            //services.Configure<JwtToken>(appSettingSection);


            //var Appsettins = appSettingSection.Get<JwtToken>();
            //var Key = Encoding.ASCII.GetBytes(Appsettins.Key);

            //services.AddAuthentication(au =>
            //{
            //    au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            //}).AddJwtBearer(jwt => {
            //    jwt.RequireHttpsMetadata = false;
            //    jwt.SaveToken = true;
            //    jwt.TokenValidationParameters = new TokenValidationParameters
            //    {

            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Key),
            //        ValidateIssuer = false,

            //    };

            //});


            services.AddInfrastructure(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //Enable CORS policy "AllowCors"  
            app.UseCors("AllowCors");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
