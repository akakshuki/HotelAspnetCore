using Api.Models.DTOs;

using AutoMapper;
using Data.Entities;
using Data.Enums;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
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

        public async Task CreateBooking(BookMv book)
        {
            try
            {
                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
                MyMailMessage.From = new System.Net.Mail.MailAddress("giangbaccai1207@gmail.com");
                MyMailMessage.To.Add("le.dinhhoang.1207@gmail.com");// Mail would be sent to this address
                MyMailMessage.Subject = "Khach San";

                System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                SMTPServer.Port = 587;
                SMTPServer.Credentials = new System.Net.NetworkCredential("giangbaccai1207@gmail.com", "dinhhoang0712");
                SMTPServer.EnableSsl = true;


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
    }
}