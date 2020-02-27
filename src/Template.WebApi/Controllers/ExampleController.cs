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
        private readonly IOptions<ExampleOptions> _exampleOptions;
        private readonly IUnitOfWork _unitOfWork;

        public ExampleController(IOptions<ExampleOptions> exampleOptions, IUnitOfWork unitOfWork)
        {
            _exampleOptions = exampleOptions;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IList<Example>> GetAll()
        {
            return await _unitOfWork.ExampleRepository.GetAll();
        }

        [HttpPost]
        public async Task Add(Example example)
        {
            await _unitOfWork.ExampleRepository.AddAsync(example);
            await _unitOfWork.SaveChangesAsync();
        }

        [HttpGet("settings")]
        public Task<ExampleOptions> GetSettings()
        {
            return Task.FromResult(_exampleOptions.Value);
        }
    }
}