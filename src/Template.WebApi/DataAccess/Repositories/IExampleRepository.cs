using System.Collections.Generic;
using System.Threading.Tasks;
using Template.WebApi.Models;

namespace Template.WebApi.DataAccess.Repositories
{
    public interface IExampleRepository
    {
        Task<IList<Example>> GetAll();
        Task Add(Example example);
    }
}