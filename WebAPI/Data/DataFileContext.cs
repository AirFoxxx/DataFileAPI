using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataFileContext : DbContext
    {
        public DataFileContext(DbContextOptions<DataFileContext> options) : base(options)
        {
        }

        // Model representation for DataFiles
        public DbSet<DataFile> DataFiles { get; set; }
    }
}
