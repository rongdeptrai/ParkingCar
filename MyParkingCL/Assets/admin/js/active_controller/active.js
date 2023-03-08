var cus = {
    inint: function () {
        cus.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click',
            function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                $.ajax({
                    url: "/Admin/Parking/ChangeStatus",
                    data: { id:id },
                    datatype: "json",
                    type:"POST",
                    success: function(response) {
                                console.log(response);
                        if (response.status == true) {
                            window.location.reload();
                                    btn.text('Xuất bãi');
                                    btn.removeClass('btn-danger');
                                    btn.addClass('btn-success');
                                  
                                }
                                else {
                                    btn.text('Xác nhận vào bãi');
                                    btn.removeClass('btn-success');
                                    btn.addClass('btn-danger');
                                   
                                }
                            }
                });
            });
    }
}
cus.inint()