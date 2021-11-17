using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class DataFileAPIProfile : Profile
    {
        public DataFileAPIProfile()
        {
            CreateMap<ReadDataFileDto, DataFile>()
                .ForMember(dest =>
                dest.Data,
                opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Data)));

            CreateMap<DataFile, SendDataFileDto>();

            CreateMap<DataFile, SendFullDataFileDto>()
                .ForMember(dest =>
                dest.Data,
                opt => opt.MapFrom(src => Encoding.ASCII.GetString(src.Data)));
        }
    }
}
