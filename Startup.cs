using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using WebApi.Settings;
using MongoDB.Driver;
using WebApi.Interfaces;
using WebApi.Repository;
using WebApi.Services;
using WebApi.Factory;
namespace WepApi
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
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MongoDb:Database").Value;
            });
            services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(Configuration.GetSection("MongoDb:ConnectionString").Value));

            //services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IServiceFactory<>), typeof(ServiceFactory<,>));
            services.AddControllers();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enable CORS
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
