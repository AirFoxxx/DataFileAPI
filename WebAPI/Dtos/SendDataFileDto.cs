using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    /// <summary>
    /// A class made to send back the user created object. Data ommited for speediness.
    /// </summary>
    public class SendDataFileDto
    {
        public int Id { get; set; }

        public int SizeInBytes { get; set; }

        public string Description { get; set; }

        public string Extension { get; set; }
    }
}
