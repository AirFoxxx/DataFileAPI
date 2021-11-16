using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// Database representation of a file.
    /// </summary>
    public class DataFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SizeInBytes { get; set; }

        public string Description { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [Required]
        public string Extension { get; set; }
    }
}
