using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.WebApi.Models;

namespace Template.WebApi.DataAccess
{
    public interface IExampleRepository
    {
        Task<IList<Example>> GetAll();
    }

    public class ExampleRepository : IExampleRepository
    {
        private readonly TemplateContext templateContext;

        public ExampleRepository(TemplateContext templateContext)
        {
            this.templateContext = templateContext;
        }

        public Task<IList<Example>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}