using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Identity.Dapper.SqlServer;
using Identity.Dapper;
using Identity.Dapper.Entities;

namespace BlogClub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IConfigurationRoot Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true);

            ///生成配置
            Configuration = builder.Build();


        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDapperSqlServerConnectionProvider(Configuration.GetSection("DapperIdentity"))
                   .ConfigureDapperIdentityCryptography(Configuration.GetSection("DapperIdentityCryptography"));

            //services.ConfigureDapperPostgreSqlConnectionProvider(Configuration.GetSection("DapperIdentity"))
            //        .ConfigureDapperIdentityCryptography(Configuration.GetSection("DapperIdentityCryptography"));

            services.AddIdentity<DapperIdentityUser, DapperIdentityRole<int>>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 1;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
            })
                    //.AddDapperIdentityForPostgreSql()
                    .AddDapperIdentityForSqlServer()
                    .AddDefaultTokenProviders();
            services.AddMvc();
          //  services.AddOptions();
            
            //  services.AddDbContext
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
