using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Template.WebApi.Configuration;
using Template.WebApi.DataAccess.Context;
using Template.WebApi.DataAccess.Repositories;

namespace Template.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(
                options => { options.ReportApiVersions = true; });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            
            services.Configure<ExampleOptions>(Configuration.GetSection(nameof(ExampleOptions)));
            
            var connectionString = new ConnectionString();
            var connectionStringsSection = Configuration.GetSection(nameof(ConnectionString));
            connectionStringsSection.Bind(connectionString);
            services.AddDbContext<TemplateContext>(options => options.UseSqlite(connectionString.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(TemplateContext).GetTypeInfo().Assembly.GetName()
                        .Name)));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = "";
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                });
        }
    }
}