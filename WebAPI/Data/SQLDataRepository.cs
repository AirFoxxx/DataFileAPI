using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    /// <inheritdoc />
    public class SQLDataRepository : IDataRepository
    {
        private readonly DataFileContext _context;

        public SQLDataRepository(DataFileContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<DataFile> AddFileAsync(DataFile file)
        {
            var obj = await _context.DataFiles.AddAsync(file);
            return obj.Entity;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<DataFile> GetAllFiles()
        {
            return _context.DataFiles.ToList();
        }

        /// <inheritdoc />
        public DataFile GetFileById(int id)
        {
            return _context.DataFiles.FirstOrDefault(obj => obj.Id == id);
        }

        /// <inheritdoc />
        public IEnumerable<DataFile> GetFilesByExtension(string extension)
        {
            return _context.DataFiles
                .Where(obj => obj.Extension.ToLower()
                .Replace(".", string.Empty) == extension.ToLower()
                .Replace(".", string.Empty)).ToList();
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
