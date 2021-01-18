
$(function () {
    $('#Customer_CityId').change(function () {
        var cityId = $('#Customer_CityId').val();
        if (cityId > 0) {
            $.ajax({
                url: '/Customer/DistrictFill',
                data: { cityId: cityId },
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    $('#Customer_DistrictId').empty();
                    //$('#Customer_DistrictId-error').remove();
                    for (var i = 0; i < data.length; i++) {
                        $('#Customer_DistrictId').append("<option value='" + data[i].Id + "'>" + data[i].DistrictName + "</option>");
                    }
                }
            });
        }
        else {
            $('#Customer_DistrictId').empty();
            $('#Customer_DistrictId').append("<option value='0'>İlçe Seçiniz</option>");
        }
    });
});

$(function () {
    $('#Address_CityId').change(function () {
        var cityId = $('#Address_CityId').val();
        if (cityId > 0) {
            $.ajax({
                url: '/Customer/DistrictFill',
                data: { cityId: cityId },
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    $('#Address_DistrictId').empty();
                    //$('#Customer_DistrictId-error').remove();
                    for (var i = 0; i < data.length; i++) {
                        $('#Address_DistrictId').append("<option value='" + data[i].Id + "'>" + data[i].DistrictName + "</option>");
                    }
                }
            });
        }
        else {
            $('#Address_DistrictId').empty();
            $('#Address_DistrictId').append("<option value='0'>İlçe Seçiniz</option>");
        }
    });
});