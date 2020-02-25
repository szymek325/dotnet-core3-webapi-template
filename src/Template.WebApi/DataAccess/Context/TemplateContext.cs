using Microsoft.EntityFrameworkCore;
using Template.WebApi.Models;

namespace Template.WebApi.DataAccess.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>().HasKey(x => x.Id);
            modelBuilder.Entity<Example>().Property(x => x.Name);

            FillData(modelBuilder);
        }

        private static void FillData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>().HasData(DataFiller.CreateExamplesTestData());
        }
    }
}