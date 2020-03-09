using Api.Models.DTOs;

using AutoMapper;
using Data.Entities;
using Data.Enums;
using System;
using UnitOfWork;

namespace Api.Models.Dao
{
    public class BookingDao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      

        public BookingDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
       
        }

        public void CreateBooking(BookMv book)
        {
         
            try
            {
                var guestData = new Guest()
                {
                    FirstName = book.FirstName,
                    LastName = book.LastName,
                    Email = book.Email,
                    Phone = book.Phone
                };

                var currentGuest = _unitOfWork.Guests.InsertData(guestData);

                _unitOfWork.Commit();

                var bookingData = new Booking()
                {
                    BookingDate = DateTime.Now,
                    CheckIn = book.CheckIn,
                    CheckOut = book.CheckOut,
                    SecretCode = new Random().Next(100000, 999999).ToString(),
                    GuestId = currentGuest.Id,
                    Status = BookedStatus.booking,
                    DurationStay = (int)(book.CheckOut - book.CheckIn).TotalDays,
                };

                _unitOfWork.Bookings.Insert(bookingData);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}