using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFilesController : ControllerBase
    {
        private readonly IDataRepository _repository;

        public DataFilesController(IDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilesAsync()
        {
            var allFiles = await _repository.GetAllFilesAsync();
            return Ok(allFiles);
        }
    }
}
