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
    [Produces("application/json")]
    public class DataFilesController : ControllerBase
    {
        private readonly IDataRepository _repository;
        private readonly IMapper _mapper;

        public DataFilesController(IDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the dataFile by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Ok if succes, oterwise not found.</returns>
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

        /// <summary>
        /// Gets the data files by extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>Ok if succes</returns>
        [HttpGet("extensions/{extension}", Name = "GetDataFilesByExtension")]
        public IActionResult GetDataFilesByExtension(string extension)
        {
            var filteredFiles = _repository.GetFilesByExtension(extension);
            return Ok(filteredFiles);
        }

        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <returns>Ok if succes.</returns>
        [HttpGet]
        public IActionResult GetAllFiles()
        {
            var allFiles = _repository.GetAllFiles();
            return Ok(allFiles);
        }

        /// <summary>
        /// Adds the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>Created(Resource_without_data) if success, otherwise not Found.</returns>
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
