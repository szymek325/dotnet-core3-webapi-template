using System.Threading.Tasks;

namespace Template.WebApi.DataAccess
{
    public interface IUnitOfWork
    {
        IExampleRepository ExampleRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }

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