using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WarmUpCache.DAL;
using WarmUpCache.Services;

namespace WarmUpCache
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
            services.AddControllers();
            
            services.AddSingleton<ICacheWarmUpService, CacheWarmUpService>();
            services.AddSingleton<ICityRepository, CityRepository>();
            services.AddSingleton<ICityService, CityService>();

            services.AddMemoryCache();

            services.AddHangfire(c => c.UseMemoryStorage());
            services.AddHangfireServer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WarmUpCache", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarmUpCache v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireServer();
            var _cacheWarmUpService = app.ApplicationServices.GetService<ICacheWarmUpService>(); 
            BackgroundJob.Enqueue(() => _cacheWarmUpService.WarmUp());
        }
    }
}