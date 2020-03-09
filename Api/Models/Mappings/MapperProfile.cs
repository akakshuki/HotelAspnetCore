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
            CreateMap<Room, RoomMv>();
            CreateMap<CategoryService, CategoryServicesMv>();
            CreateMap<Service, ServiceMv>();

            CreateMap<Booking, BookingMv>();
            CreateMap<Guest, GuestMv>();
        }
    }
}