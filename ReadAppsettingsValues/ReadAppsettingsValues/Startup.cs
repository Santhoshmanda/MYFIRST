using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ReadAppsettingsValues
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<POCO>(Configuration.GetSection("MySettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(next =>
            {
                return async ctx =>
                {
                    ctx.AddLogItem("Enter middleware 1");
                    await next(ctx);
                    ctx.AddLogItem("Exit middleware 1");
                };
            });

            app.Use(next =>
            {
                return async ctx =>
                {
                    ctx.AddLogItem("Enter middleware 2");
                    await next(ctx);
                    ctx.AddLogItem("Exit middleware 2");
                };
            });

            app.Use(next =>
            {
                return async ctx =>
                {
                    ctx.AddLogItem("Enter middleware 3");
                    await next(ctx);
                    ctx.AddLogItem("Exit middleware 3");
                };
            });

            //app.UseMiddleware();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
