using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class DataFileAPIProfile : Profile
    {
        public DataFileAPIProfile()
        {
            CreateMap<DataFile, ReadDataFileDto>();
        }
    }
}
