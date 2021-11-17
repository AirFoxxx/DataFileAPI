using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    /// <summary>
    /// The data object representing a file that is returned when requested by id.
    /// </summary>
    public class SendFullDataFileDto
    {
        public int SizeInBytes { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }

        public string Extension { get; set; }
    }
}
