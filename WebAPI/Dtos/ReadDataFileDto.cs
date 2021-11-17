using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    /// <summary>
    /// A class made to read the user input DataFile.
    /// </summary>
    public class ReadDataFileDto
    {
        [Required]
        public int SizeInBytes { get; set; }

        public string Description { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Extension { get; set; }
    }
}
