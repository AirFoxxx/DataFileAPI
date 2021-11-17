using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SQLDataRepository : IDataRepository
    {
        private readonly DataFileContext _context;

        public SQLDataRepository(DataFileContext context)
        {
            _context = context;
        }

        public async Task<DataFile> AddFileAsync(DataFile file)
        {
            var obj = await _context.DataFiles.AddAsync(file);
            return obj.Entity;
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataFile> GetAllFiles()
        {
            return _context.DataFiles.ToList();
        }

        public DataFile GetFileById(int id)
        {
            return _context.DataFiles.FirstOrDefault(obj => obj.Id == id);
        }

        public IEnumerable<DataFile> GetFilesByExtension(string extension)
        {
            return _context.DataFiles.Where(obj => obj.Extension.ToLower() == extension.ToLower()).ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
