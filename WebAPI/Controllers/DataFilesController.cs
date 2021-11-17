using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFilesController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
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
        /// <response code="200">Returns OK.</response>
        /// <response code="404">Returns if item is not found.</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <response code="200">Returns OK.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <response code="200">Returns OK.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <response code="201">Returns Created + the object without the hefty file content.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddFileAsync(ReadDataFileDto file)
        {
            var fileToSave = _mapper.Map<DataFile>(file);

            var savedFile = await _repository.AddFileAsync(fileToSave);
            await _repository.SaveChangesAsync();

            var returnedFile = _mapper.Map<SendDataFileDto>(savedFile);
            return CreatedAtRoute(nameof(GetDataFileById), new { Id = returnedFile.Id }, returnedFile);
        }

        /// <summary>
        /// Deletes the data file by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Not found if file is not found, and otherwise No content.</returns>
        /// <response code="404">Returns if item is not found.</response>
        /// <response code="204">Returns No Content if deleted successfully.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteDataFileById(int id)
        {
            var returnedItem = _repository.GetFileById(id);
            if (returnedItem == null)
            {
                return NotFound();
            }

            _repository.DeleteFile(returnedItem.Id);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
