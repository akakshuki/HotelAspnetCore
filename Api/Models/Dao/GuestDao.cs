using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTOs;
using AutoMapper;
using UnitOfWork;

namespace Api.Models.Dao
{
    public class GuestDao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuestDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<GuestMv> GetListGuest()
        {
            var data = _unitOfWork.Guests.Get();
            var listGuest = _mapper.Map<List<GuestMv>>(data).Take(100).OrderByDescending(x=>x.Id).ToList();
            return listGuest;
        }
    }
}
