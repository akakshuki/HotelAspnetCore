using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;

namespace Api.Models.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryRoom, CategoryRoomMv>();
        }

    }
}
