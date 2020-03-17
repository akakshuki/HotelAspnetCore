using Api.Models.DTOs;

using AutoMapper;
using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public bool checkGuest(string email)
        {
                var data = _unitOfWork.Guests.Get().Where(x => x.Email == email).FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task CreateBooking(BookMv book)
        {
            try
            {
                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
                MyMailMessage.From = new System.Net.Mail.MailAddress("giangbaccai1207@gmail.com");
                MyMailMessage.To.Add(book.Email);// Mail would be sent to this address
                MyMailMessage.Subject = "Khach San";

                System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                SMTPServer.Port = 587;
                SMTPServer.Credentials = new System.Net.NetworkCredential("giangbaccai1207@gmail.com", "dinhhoang0712");
                SMTPServer.EnableSsl = true;

                var guest = _unitOfWork.Guests.Get().Where(x => x.Email == book.Email).FirstOrDefault();
                var currentGuest = new Guest();
                if (guest != null)
                {
                    currentGuest = guest;
                }
                else
                {
                    var guestData = new Guest()
                    {
                        FirstName = book.FirstName,
                        LastName = book.LastName,
                        Email = book.Email,
                        Phone = book.Phone
                    };
                    currentGuest = _unitOfWork.Guests.InsertData(guestData);
                }
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
                MyMailMessage.Body = $"ma so bi mat ban la: {bookingData.SecretCode}";
                _unitOfWork.Bookings.Insert(bookingData);
                _unitOfWork.Commit();
                await SMTPServer.SendMailAsync(MyMailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }

        public async Task EmployeCreateBooking(BookMv book)
        {
            try
            {
                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
                MyMailMessage.From = new System.Net.Mail.MailAddress("giangbaccai1207@gmail.com");
                MyMailMessage.To.Add(book.Email);// Mail would be sent to this address
                MyMailMessage.Subject = "khách sạn";

                System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                SMTPServer.Port = 587;
                SMTPServer.Credentials = new System.Net.NetworkCredential("giangbaccai1207@gmail.com", "dinhhoang0712");
                SMTPServer.EnableSsl = true;

                var guest = _unitOfWork.Guests.Get().Where(x => x.Email == book.Email).FirstOrDefault();
                var currentGuest = new Guest();
                if (guest == null )
                {
                    var guestData = new Guest()
                    {
                        FirstName = book.FirstName,
                        LastName = book.LastName,
                        Email = book.Email,
                        Phone = book.Phone,
                        IdentityNo = book.IdentityNo

                    };
                    currentGuest = _unitOfWork.Guests.InsertData(guestData);

                }
                else
                {
                    currentGuest = guest;
                   
                }
                _unitOfWork.Commit();
                var amountMoney = 0;
                
                foreach (var item in book.ListRoomIds)
                {
                    var money = _unitOfWork.CategoryRooms
                        .GetByID(_unitOfWork.Rooms.GetByID(item).CategoryRoomId)
                        .Price;
                    var durationDay = (int) (book.CheckOut - book.CheckIn).TotalDays;

                    var totalMoney = durationDay * money;
                    amountMoney += (int)totalMoney;
                }
                var bookingData = new Booking()
                {
                    BookingDate = DateTime.Now,
                    CheckIn = book.CheckIn,
                    CheckOut = book.CheckOut,
                    SecretCode = new Random().Next(100000, 999999).ToString(),
                    GuestId = currentGuest.Id,
                    Status = BookedStatus.booked,
                    DurationStay = (int)(book.CheckOut - book.CheckIn).TotalDays,
                    Amount = amountMoney
                };
                

                MyMailMessage.Body = $"mã số bí mật của {currentGuest.LastName} là: {bookingData.SecretCode}";
                _unitOfWork.Bookings.Insert(bookingData);
                _unitOfWork.Commit();

                foreach (var item in book.ListRoomIds)
                {
                    var bookRoom = new BookRoom()
                    {
                        BookingId = bookingData.Id,
                        RoomId = item

                    };
                    _unitOfWork.BookRooms.Insert(bookRoom);
                     _unitOfWork.Commit();
                }

                await SMTPServer.SendMailAsync(MyMailMessage);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public List<BookingMv> GetListBookingOnline()
        {
            var data = _unitOfWork.Bookings.Get().Where(x => x.Status == BookedStatus.booking).OrderByDescending(x=>x.BookingDate).ToList();
            var guests = _unitOfWork.Guests.Get();
            var listGuests = _mapper.Map<List<GuestMv>>(guests);
            var list = _mapper.Map<List<BookingMv>>(data);
            foreach (var bookingMv in list)
            {
                bookingMv.GuestMv = listGuests.Where(x => x.Id == bookingMv.GuestId).SingleOrDefault();
            }
            return list;
        }

        public List<BookingMv> GetListBooking()
        {
            var data = _unitOfWork.Bookings.Get().Where(x => x.Status == BookedStatus.booked).OrderByDescending(x => x.BookingDate).ToList();
            var list = _mapper.Map<List<BookingMv>>(data);
            return list;
        }
    }
}