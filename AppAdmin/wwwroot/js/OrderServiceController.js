const baseController = 'https://localhost:44338/';
var service = {
    id: 0,
    name: '',
    price: 0,
    categoryServiceId: 0,
    serviceName: '',
    quantity: 0
};

var sevices = [];

OrderService = {
    init() {
        OrderService.RegisterEvent();
    },
    RegisterEvent() {
        $('.button-cate').on('click',
            function () {
                OrderService.GetServices($(this).attr('data-idCate'));
            });

        $('.btn-addservice').on('click',
            function () {
                OrderService.SetServicesToOrderService($(this).attr('data-idservice'));
            });
        $().on('click', function() {
            
        });

    },
    OrderEvent() {
        $('.btn-delete-orderService').on('click',
            function() {
                OrderService.removeItem($(this).attr('data-idDelete'));
            });
    },
    GetServices(id) {
        $.ajax({
            url: baseController + 'Booking/GetServicesByCategoryId',
            type: 'GET',
            dataType: 'json',
            data: {
                id: id
            },
            success: function (res) {
                var data = res.data;
                var html = '';
                var template = $('#data-template-category').html();

                $.each(data,
                    function (i, item) {
                        html += Mustache.render(template,
                            {
                                id: item.id,
                                name: item.name,
                                price: item.price,
                                categoryName: item.categoryServicesMv.name

                            });
                    });
                $('#ServiceRender').html(html);
                OrderService.RegisterEvent();
            }
        });
    },
    SetServicesToOrderService(id) {
        $.ajax({
            url: baseController + 'Booking/SetListOrderService',
            type: 'get',
            dataType: 'json',
            data: {
                idService: id
            },
            success(res) {
                var data = res.data;
                var html = '';
                var template = $('#data-template-service').html();

                $.each(data,
                    function (i, item) {
                        html += Mustache.render(template,
                            {
                                id: item.id,
                                name: item.name,
                                price: item.price,
                                categoryName: item.categoryName,
                                quantity: item.quantity
                            });

                    });

                $('#orderServiceRender').html(html);
                OrderService.OrderEvent();
            }
        });
    },
    removeItem(itemId) {
        $.ajax({
            url: baseController + 'Booking/removeItemOrder',
            type: 'get',
            dataType: 'json',
            data: {
                idService: itemId
            },
            success(res) {
                var data = res.data;
                var html = '';
                var template = $('#data-template-service').html();

                $.each(data,
                    function (i, item) {
                        html += Mustache.render(template,
                            {
                                id: item.id,
                                name: item.name,
                                price: item.price,
                                categoryName: item.categoryName,
                                quantity: item.quantity
                            });

                    });

                $('#orderServiceRender').html(html);
                OrderService.OrderEvent();
            }
        });
    }

}
OrderService.init();