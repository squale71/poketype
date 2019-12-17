using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poketype.Service.Data.Models;
using Poketype.Service.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace Poketype.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables("POKETYPE_");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();

            // requires using Microsoft.Extensions.Options
            services.Configure<PoketypeDatabaseSettings>(
                Configuration.GetSection(nameof(PoketypeDatabaseSettings)));

            services.AddSingleton<IPoketypeDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PoketypeDatabaseSettings>>().Value);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "PokeType API",
                    Description = "API for getting information about Pokemon"
                });

            });

            services.AddScoped<TypeRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poketype API");
            });
        }
    }
}
