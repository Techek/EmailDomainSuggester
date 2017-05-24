using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dgi.Email.ApplicationService.Services;
using Dgi.Email.Dal.Repositories;
using Dgi.Email.Delt.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dgi.Host
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailService, EmailService>();

            //Assembly assembly = null;
            //assembly = typeof(Dgi.Email.ApplicationService.Services.EmailService).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.Dal.Repositories.EmailRepository).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.Dal.Repositories.IEmailRepository).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.Delt.Dtoer.QueryDto).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.Delt.Dtoer.QueryResultDto).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.Delt.Interfaces.IEmailService).GetTypeInfo().Assembly;
            //assembly = typeof(Dgi.Email.WebApi.Controllers.EmailController).GetTypeInfo().Assembly;

            services.AddMvc();

            //services.AddMvc().AddApplicationPart(assembly);
            //services.AddApplicationPart(typeof().GetTypeInfo().Assembly);
            //services.AddMvc().AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Nothing here");
            });
        }
    }
}

// https://weblog.west-wind.com/posts/2016/jun/29/first-steps-exploring-net-core-and-aspnet-core
// https://msdn.microsoft.com/en-us/magazine/mt703433.aspx
// https://msdn.microsoft.com/en-us/magazine/mt707534.aspx