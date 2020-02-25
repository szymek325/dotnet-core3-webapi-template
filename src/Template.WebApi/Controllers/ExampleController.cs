using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.WebApi.DataAccess.Repositories;
using Template.WebApi.Models;

namespace Template.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/examples")]
    public class ExampleController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExampleController(IUnitOfWork unitOfWork)
        {
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
            await _unitOfWork.ExampleRepository.Add(example);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}