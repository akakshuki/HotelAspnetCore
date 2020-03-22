const baseUrl ='https://localhost:44338/';
roomIds = [];
booking = {

    init() {
        booking.registerFunc();
    },
    registerFunc() {
        $("#Email").focusout(function () {
            booking.checkEmail($("#Email").val());
        });

        $('.categoryItem').click(function () {
            roomIds = [];
            booking.getListRoomByCategory($(this).attr("data-id"));
        });

        $(".buttonRoom").on('click',
            function () {
                if ($(this).hasClass('RoomSelected')) {
                    var id = $(this).attr("data-id");
                    $(this).removeClass('RoomSelected');
                    booking.removeList(id);
                } else {
                    $(this).last().addClass('RoomSelected');
                    var idRoom = $(this).attr("data-id");
                    booking.selectListRoom(idRoom);
                }
            });
        $('.BookingOnlineRow').on('click',
            function () {
                booking.getOnlineBooking($(this).attr('data-id'));
            });

        $('#buttonSearchSecretCode').on('click', function() {
            booking.searchDetailOrderBySecretCode($('#searchCodeInput').val());
        });

        $('.bookedData').on('click',
            function() {
                booking.searchDetailOrderBySecretCode($(this).attr('data-secretCode'));
            });
    },
    checkEmail(data1) {
        $.ajax({
            url: baseUrl + 'Booking/checkEmail',
            type: 'GET',
            dataType: 'Json',
            data: {
                email: data1
            },
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.data) {
                    $.notify("đã có", "warn");
                } else {
                    $.notify("Chưa có", "success");
                }
            },
            error: function (err) {
                console.log(err.message);
            }
        });



    },
    getListRoomByCategory(idCate) {
        $.ajax({
            url: baseUrl + 'Booking/GetRoomsByCategoryId',
            type: 'GET',
            dataType: 'Json',
            data: {
                idCate: idCate
            },
            success: function (res) {
                var data = res.data;
                var html = '';
                var template = $('#data-template').html();

                $.each(data,
                    function (i, item) {
                        html += Mustache.render(template,
                            {
                                id: item.id,
                                name: item.roomNo
                            });
                    });
                $('#dataRender').html(html);
                booking.registerFunc();
            }
        });
    },

    removeList(id) {
        roomIds.forEach((value, index) => {
            if (value === id) {
                roomIds.splice(index, 1);
                $('#RoomIds').val(roomIds);
            }
        });
    },

    selectListRoom(id) {
        roomIds.push(id);
        $('#RoomIds').val(roomIds);
    },
    getOnlineBooking(id) {
        $.ajax({
            url: baseUrl + 'Booking/GetBookingById',
            type: 'GET',
            dataType: 'Json',
            data: {
                bookingId: id
            },
            success: function (res) {
                $('#Id').val(res.data.id);
                $('#FirstName').val(res.data.firstName);
                $('#LastName').val(res.data.lastName);
                $('#Phone').val(res.data.phone);
                $('#Email').val(res.data.email);
                $('#IdentityNo').val(res.data.identityNo);
                $('#timeCheckIn').val(res.data.checkIn);
                $('#timeCheckOut').val(res.data.checkOut);
            },
            error: function (err) {
                console.log(err.message);
            }
        });
    },

    searchDetailOrderBySecretCode(secretCode) {
       
        window.location.href =  baseUrl+ "Booking/GetDetailOrder?secretCode="+ secretCode;
            
    }



}
booking.init(); 