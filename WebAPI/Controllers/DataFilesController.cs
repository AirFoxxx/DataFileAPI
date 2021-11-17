using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Dtos;
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

        [HttpGet("{id}", Name = "GetDataFileById")]
        public IActionResult GetDataFileById(int id)
        {
            var foundFile = _repository.GetFileById(id);
            if (foundFile != null)
            {
                return Ok(_mapper.Map<SendFullDataFileDto>(foundFile));
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAllFilesAsync()
        {
            var allFiles = _repository.GetAllFiles();
            return Ok(allFiles);
        }

        [HttpPost]
        public async Task<IActionResult> AddFileAsync(ReadDataFileDto file)
        {
            var fileToSave = _mapper.Map<DataFile>(file);

            var savedFile = await _repository.AddFileAsync(fileToSave);
            await _repository.SaveChangesAsync();

            if (savedFile != null)
            {
                var returnedFile = _mapper.Map<SendDataFileDto>(savedFile);
                return CreatedAtRoute(nameof(GetDataFileById), new { Id = returnedFile.Id }, returnedFile);
            }

            return NotFound();
        }
    }
}
