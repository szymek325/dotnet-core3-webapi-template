using System.Threading.Tasks;

namespace Template.WebApi.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IExampleRepository ExampleRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}