$(function () {
    $('#datetimepicker1').datetimepicker({
        minDate: new Date(),
        format: 'MM/DD/YYYY'



    });

    $('#datetimepicker2').datetimepicker({
        minDate: new Date(),
        format: 'MM/DD/YYYY'

    });

    $.ajax({
        url: "/getbikes",
        type: "GET",
        success: function (res) {
            var option = '';
            for (var i = 0; i < res.length; i++) {
                option += '<option value="' + res[i].BikeName + '">' + res[i].BikeName + '</option>';
            }
            $('#items').append(option);
        }
    });

    

    $("#getcustomers").click(function () {
        $.ajax({
            url: '/getcustomer/'+$('#customerid').val()+'',
            type: "GET",       
            success: function (res) {
                if (res.errorcode=="999") {
                    //$('#error').text();
                    //document.getElementById('error').innerHTML += res.error;
                    alert(res.error);
                }
                else {
                    $('#firstname').val(res.Firstname);
                    $('#lastname').val(res.Lastname);
                    $('#phoneno').val(res.Phoneno);
                    $('#id').val(res.Phoneno);

                }
               
            }
        });
    });


    //var numbers = [1, 2, 3, 4, 5];
    //var option = '';

    //for (var i = 0; i < numbers.length; i++) {
    //    option += '<option value="' + numbers[i] + '">' + numbers[i] + '</option>';
    //}
   

    //$form = $(".form-horizontal");
    //$form.on("submit", function () {
    //    alert("submitting..");
    //    //do ajax
    //    $.ajax({
    //        url: "/rentals/new",
    //        type: "GET",
    //        data: { fromdate: $('#fromdate').val(), todate: $('#todate').val() },
    //        success: function (res) {
    //            if (res.errorcode == "999") {
    //                alert(res.errordes);
    //            }

    //        },
    //        error: function (xhr, error) {
    //            alert("some error");

    //        }
    //    });
    //});

});