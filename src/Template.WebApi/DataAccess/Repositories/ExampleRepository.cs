using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.WebApi.DataAccess.Context;
using Template.WebApi.Models;

namespace Template.WebApi.DataAccess.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly TemplateContext _templateContext;

        public ExampleRepository(TemplateContext templateContext)
        {
            _templateContext = templateContext;
        }

        public async Task<IList<Example>> GetAll()
        {
            return await _templateContext.Examples.ToListAsync();
        }

        public async Task Add(Example example)
        {
            await _templateContext.Examples.AddAsync(example);
        }
    }
}