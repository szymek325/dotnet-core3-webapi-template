using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Template.WebApi.Configuration;
using Template.WebApi.DataAccess.Repositories;
using Template.WebApi.Models;

namespace Template.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/examples")]
    public class ExampleController
    {
        private readonly IOptions<ExampleOptions> exampleOptions;
        private readonly IUnitOfWork unitOfWork;

        public ExampleController(IOptions<ExampleOptions> exampleOptions, IUnitOfWork unitOfWork)
        {
            this.exampleOptions = exampleOptions;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IList<Example>> GetAll()
        {
            return await unitOfWork.ExampleRepository.GetAll();
        }

        [HttpPost]
        public async Task Add(Example example)
        {
            await unitOfWork.ExampleRepository.Add(example);
            await unitOfWork.SaveChangesAsync();
        }

        [HttpGet("settings")]
        public Task<ExampleOptions> GetSettings()
        {
            return Task.FromResult(exampleOptions.Value);
        }
    }
}