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
            function() {
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
            function() {
                booking.getOnlineBooking($(this).attr('data-id'));
            });
    },
    checkEmail(data1) {
        $.ajax({
            url: 'https://localhost:44338/Booking/checkEmail',
            type: 'GET',
            dataType: 'Json',
            data: {
                email: data1
            },
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.data) {
                    $.notify("đã có","warn");
                } else {
                    $.notify("Chưa có","success");
                }
            },
            error: function (err) {
                console.log(err.message);
            }
        });



    },
    getListRoomByCategory(idCate) {
        $.ajax({
            url: 'https://localhost:44338/Booking/GetRoomsByCategoryId',
            type: 'GET',
            dataType: 'Json',
            data: {
                idCate: idCate
            },
            success: function(res) {
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

    }


  
}
booking.init(); 