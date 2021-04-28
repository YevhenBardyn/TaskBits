$(document).ready(function () {
    $("#UserID, #Name, #DateOfBirth, #Married, #Phone, #Salary").click(function (event) {
        $.ajax({
            type: "post",
            url: '/Home/Index?filterColumn=' + event.target.id,
            type: "POST",
            success: function (result) {
                $("#IndexRecall").html(result);
            }
        }).done(function () {
            $(this).addClass("done");
        });
    })
});