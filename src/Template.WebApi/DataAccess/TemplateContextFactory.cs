using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Template.WebApi.Configuration;

namespace Template.WebApi.DataAccess
{
    internal class TemplateContextFactory : IDesignTimeDbContextFactory<TemplateContext>
    {
        public TemplateContext CreateDbContext(string[] args)
        {
            var connectionStrings = GetConnectionString();
            var builder = new DbContextOptionsBuilder<TemplateContext>();

            builder.UseSqlite(connectionStrings.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(TemplateContext).GetTypeInfo().Assembly
                        .GetName()
                        .Name));

            return new TemplateContext(builder.Options);
        }

        private static ConnectionString GetConnectionString()
        {
            var configuration = GetConfig();
            var connectionStrings = new ConnectionString();
            configuration.GetSection(nameof(ConnectionString)).Bind(connectionStrings);
            return connectionStrings;
        }

        public static IConfigurationRoot GetConfig()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var projectPath =
                AppDomain.CurrentDomain.BaseDirectory.Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();
            return configuration;
        }
    }
}