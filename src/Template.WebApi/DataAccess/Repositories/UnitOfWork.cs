using System.Threading.Tasks;
using Template.WebApi.DataAccess.Context;

namespace Template.WebApi.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TemplateContext templateContext;
        private IExampleRepository exampleRepository;

        public UnitOfWork(TemplateContext templateContext)
        {
            this.templateContext = templateContext;
        }

        public IExampleRepository ExampleRepository
        {
            get { return exampleRepository ??= new ExampleRepository(templateContext); }
        }

        public void SaveChanges()
        {
            templateContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await templateContext.SaveChangesAsync();
        }
    }
}