using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.DTOs;
using Api.Models.DTOs;
using AutoMapper;
using UnitOfWork;
using Data.Entities;
using Data.Enums;
using MoMo;
using MomoConnector.DTO;
using MoMoConnector.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Api.Models.Dao
{
    public class OrderDao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public OrderDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public void CreateOrder(int idBooking)
        {
            var booking = _unitOfWork.Bookings.GetByID(idBooking);
            var order = new Order()
            {
                BookingId = idBooking,
                TotalAmount = booking.Amount,
                OrderNo = Guid.NewGuid()

            };
            _unitOfWork.Orders.Insert(order);
            _unitOfWork.Commit();
        }



        public OrderMv GetTotalOrder(string secretCode)
        {
            var booking = _unitOfWork.Bookings.Get().SingleOrDefault(x => x.SecretCode == secretCode);



            var bookroom = _unitOfWork.BookRooms.Get().Where(x => x.BookingId == booking.Id).Select(x => new BookRoom()
            {
                Id = x.Id,
                BookingId = x.BookingId,
                RoomId = x.RoomId,
                Room = _unitOfWork.Rooms.GetByID(x.RoomId)
            }).ToList();



            var guest = _unitOfWork.Guests.Get().SingleOrDefault(x => x.Id == booking.GuestId);

            var bookingDataView = _mapper.Map<BookingMv>(booking);

            bookingDataView.GuestMv = _mapper.Map<GuestMv>(guest);


            bookingDataView.BookRoomMvs = _mapper.Map<List<BookRoomMv>>(bookroom);

            foreach (var bookRoomMv in bookingDataView.BookRoomMvs)
            {
                bookRoomMv.Room.CategoryRoomMv =
                    _mapper.Map<CategoryRoomMv>(_unitOfWork.CategoryRooms.GetByID(bookRoomMv.Room.CategoryRoomId));
            }

            var Order = _unitOfWork.Orders.Get().SingleOrDefault(x => x.BookingId == booking.Id);

            var orderDataView = _mapper.Map<OrderMv>(Order);

            var OrderDetail = _unitOfWork.OrderDetails.Get().Where(x => x.OrderId == Order.Id).ToList();

            orderDataView.Booking = bookingDataView;

            orderDataView.OrderDetailMvs = _mapper.Map<List<OrderDetailMv>>(OrderDetail);

            foreach (var orderDataOrderDetailMv in orderDataView.OrderDetailMvs)
            {
                orderDataOrderDetailMv.ServiceMv =
                    _mapper.Map<ServiceMv>(_unitOfWork.Services.GetByID(orderDataOrderDetailMv.ServiceId));
                orderDataOrderDetailMv.ServiceMv.CategoryServicesMv =
                    _mapper.Map<CategoryServicesMv>(
                        _unitOfWork.CategoryServices.GetByID(orderDataOrderDetailMv.ServiceMv.CategoryServiceId));
            }
            return orderDataView;
        }

        public object getOrderServiceBySecretCode(string secretCode)
        {
            var booking = _unitOfWork.Bookings.Get()
                .SingleOrDefault(k => k.SecretCode == secretCode);

            var order = _unitOfWork.Orders.Get()
                .SingleOrDefault(x => x.BookingId == booking.Id);

            //orderData
            var orderData = _mapper.Map<OrderMv>(order);

            orderData.Booking = _mapper
                .Map<BookingMv>(_unitOfWork.Bookings
                    .Get()
                    .SingleOrDefault(x => x.SecretCode == secretCode));

            orderData.Booking.GuestMv = _mapper
                .Map<GuestMv>(_unitOfWork.Guests.GetByID(orderData.Booking.GuestId));



            orderData.OrderDetailMvs = _mapper.Map<List<OrderDetailMv>>(_unitOfWork.OrderDetails.Get().Where(x => x.OrderId == orderData.Id)
                    .ToList());

            foreach (var orderDataOrderDetailMv in orderData.OrderDetailMvs)
            {
                orderDataOrderDetailMv.ServiceMv =
                    _mapper.Map<ServiceMv>(_unitOfWork.Services.GetByID(orderDataOrderDetailMv.ServiceId));
                orderDataOrderDetailMv.ServiceMv.CategoryServicesMv =
                    _mapper.Map<CategoryServicesMv>(
                        _unitOfWork.CategoryServices.GetByID(orderDataOrderDetailMv.ServiceMv.CategoryServiceId));
            }
            return orderData;
        }

        public object getOrderServiceByOrderNo(Guid orderno)
        {


            var order = _unitOfWork.Orders.Get()
                .SingleOrDefault(x => x.OrderNo == orderno);

            //orderData
            var orderData = _mapper.Map<OrderMv>(order);

            orderData.Booking = _mapper
                .Map<BookingMv>(_unitOfWork.Bookings
                    .Get()
                    .SingleOrDefault(x => x.Id == orderData.BookingId));

            orderData.Booking.GuestMv =
                _mapper.Map<GuestMv>(_unitOfWork.Guests.Get().SingleOrDefault(x => x.Id == orderData.Booking.GuestId));


            orderData.Booking.GuestMv = _mapper
                .Map<GuestMv>(_unitOfWork.Guests.GetByID(orderData.Booking.GuestId));

            orderData.Booking.BookRoomMvs = _mapper.Map<List<BookRoomMv>>(_unitOfWork.BookRooms.Get().Where(x => x.BookingId == orderData.BookingId));

            foreach (var bookRoomMv in orderData.Booking.BookRoomMvs)
            {
                bookRoomMv.Room = _mapper.Map<RoomMv>(_unitOfWork.Rooms.GetByID(bookRoomMv.BookingId));
                bookRoomMv.Room.CategoryRoomMv = _mapper.Map<CategoryRoomMv>(_unitOfWork.CategoryRooms.GetByID(bookRoomMv.Room.CategoryRoomId));
            }

            orderData.OrderDetailMvs =
                _mapper.Map<List<OrderDetailMv>>(_unitOfWork.OrderDetails.Get().Where(x => x.OrderId == orderData.Id)
                    .ToList());


            foreach (var orderDataOrderDetailMv in orderData.OrderDetailMvs)
            {
                orderDataOrderDetailMv.ServiceMv =
                    _mapper.Map<ServiceMv>(_unitOfWork.Services.GetByID(orderDataOrderDetailMv.ServiceId));
                orderDataOrderDetailMv.ServiceMv.CategoryServicesMv =
                    _mapper.Map<CategoryServicesMv>(
                        _unitOfWork.CategoryServices.GetByID(orderDataOrderDetailMv.ServiceMv.CategoryServiceId));
            }
            return orderData;
        }

        public void CreateOrderDetailSerice(OrderService listOrderDetail)
        {
            var data = new OrderDetail()
            {
                Quantity = listOrderDetail.Quantity,
                DateRequest = DateTime.Now,
                OrderId = listOrderDetail.OrderId,
                ServiceId = listOrderDetail.id,
                Amount = (decimal)(listOrderDetail.Quantity * _unitOfWork.Services.GetByID(listOrderDetail.id).Price)
            };

            _unitOfWork.OrderDetails.Insert(data);
            _unitOfWork.Commit();
        }

        public void CancelBooking(string SerectCode)
        {
            var bookingData = _unitOfWork.Bookings.Get().SingleOrDefault(x => x.SecretCode == SerectCode);
            bookingData.Status = BookedStatus.canceled;
            _unitOfWork.Bookings.Update(bookingData);

        }

        public void SetOrderByCard(Guid orderNo)
        {
            var data = _unitOfWork.Orders.Get().SingleOrDefault(x => x.OrderNo == orderNo);
            var bookingData = _unitOfWork.Bookings.GetByID(data.BookingId);
            bookingData.Status = BookedStatus.completed;
            _unitOfWork.Bookings.Update(bookingData);
            _unitOfWork.Commit();
        }

        public object SetOrderByMomo(Guid orderNo, decimal money)
        {
            var orderData = _unitOfWork.Orders.Get().SingleOrDefault(x => x.OrderNo == orderNo);


            var jsonRequesy = new JsonRequest()
            {
                ApiEndPoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor",
                PartnerCode = "MOMOVYHR20200208",
                AccessKey = "dIn9mqdLZF6htCr5",
                RequestId = Guid.NewGuid().ToString(),
                Amount = ((int)money * 1000).ToString(),
                OrderId = orderNo.ToString(),
                OrderInfo = "Thanh toán khách sạn",
                ReturnUrl = "https://localhost:44338/",
                NotifyUrl = "https://localhost:5001/api/",
                RequestType = "captureMoMoWallet",
                SecretKey = "iI0Fg6R7nJUzpda4qbsYd4iFQHE9HDny",
                Signature = "",
                ExtraData = ""
            };

            string rawHash = "partnerCode=" +
                             jsonRequesy.PartnerCode + "&accessKey=" +
                             jsonRequesy.AccessKey + "&requestId=" +
                             jsonRequesy.RequestId + "&amount=" +
                             jsonRequesy.Amount + "&orderId=" +
                             jsonRequesy.OrderId + "&orderInfo=" +
                             jsonRequesy.OrderInfo + "&returnUrl=" +
                             jsonRequesy.ReturnUrl + "&notifyUrl=" +
                             jsonRequesy.NotifyUrl + "&extraData=" +
                             jsonRequesy.ExtraData;



            string signature = new MoMoSecurity().signSHA256(rawHash, jsonRequesy.SecretKey);


            JObject message = new JObject
            {
                { "partnerCode", jsonRequesy.PartnerCode },
                { "accessKey", jsonRequesy.AccessKey },
                { "requestId", jsonRequesy.RequestId },
                { "amount", jsonRequesy.Amount },
                { "orderId", jsonRequesy.OrderId },
                { "orderInfo", jsonRequesy.OrderInfo },
                { "returnUrl", jsonRequesy.ReturnUrl },
                { "notifyUrl", jsonRequesy.NotifyUrl },
                { "extraData", jsonRequesy.ExtraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(jsonRequesy.ApiEndPoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);
            return jmessage.GetValue("payUrl").ToString();
        }
    }
}
