var homeController = {
    init: function () {
        homeController.loadData();

    },
    registerEvent: function () {
        $('.txtAge').off('keypress').on('keypress', function (e) {
            if (e.which==13) {
                var id = $(this).data('id');
                var value = $(this).val();

                homeController.updateAge(id, value);
            }
        });
    },

    updateAge: function (id, value) {
        var data = {
            Id: id,
            Age: value
        };

        $.ajax({
            url: '/Home/Update',
            type: 'POST',
            dataType: 'json',
            data: {model: JSON.stringify(data)},
            success: function (response) {
                if (response.status) {
                    alert("update thanh cong");
                } else {
                    alert("update false");
                }
            }
        })
    },

    loadData: function () {
        $.ajax({
            url: 'Home/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Age: item.Age,
                            Status: item.Status == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Locked</span>"
                        });

                    });
                    $('#tblData').html(html);
                    homeController.registerEvent();

                }
            }
        })
    }
}
homeController.init();