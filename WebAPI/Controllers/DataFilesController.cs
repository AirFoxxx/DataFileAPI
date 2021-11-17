using AutoMapper;
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
        private readonly IMapper _mapper;

        public DataFilesController(IDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilesAsync()
        {
            var allFiles = await _repository.GetAllFilesAsync();
            return Ok(allFiles);
        }

        [HttpPost]
        public async Task<IActionResult> AddFileAsync(DataFile file)
        {
            var returnedFile = await _repository.AddFileAsync(file);

            return CreatedAtRoute(nameof(returnedFile), new { Id = returnedFile.Id }, returnedFile);
        }
    }
}
