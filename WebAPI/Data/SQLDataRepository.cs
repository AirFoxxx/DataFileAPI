using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SQLDataRepository : IDataRepository
    {
        public Task<bool> AddFileAsync(DataFile file)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DataFile>> GetAllFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DataFile> GetFileByNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
