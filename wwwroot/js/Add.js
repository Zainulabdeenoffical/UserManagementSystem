/*$(document).ready(function () {
    $("#addUserForm").validate({
        rules: {
            First_name: {
                required: true,
            },
            Last_name: {
                required: true,
            },
            Email: {
                required: true,
                email: true
            },
        },
        messages: {
            First_name: {
                required: "Please enter first name",
            },
            Last_name: {
                required: "Please enter last name",
            },
            Email: {
                required: "Please enter your email",
                email: "Please enter a valid email address"
            },
        }
    });
}); */

$("#Adddata").click(function () {
    $("#usermodal").modal('show');
});

$("#saveBtn").click(function () {
    if (!$("#addUserForm").valid()) {
        alert("Valiations are missing");
        return;
    }

    var objdata = {
        firstName: $('#First_name').val(),
        lastName: $('#Last_name').val(),
        email: $('#Email').val()
    };

    $.ajax({
        url: '/user/AddUser',
        type: 'POST',
        data: JSON.stringify(objdata),
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('data saved');
            $("#usermodal").modal('hide');
        },
        error: function (error) {
            alert('data can\'t be saved');
        }
    });

});

function addUser() {
    if (!$("#addUserForm").valid()) {
        alert("Valiations are missing");
        return;
    }

    var objdata = {
        firstName: $('#First_name').val(),
        lastName: $('#Last_name').val(),
        email: $('#Email').val()
    };

    $.ajax({
        url: '/user/AddUser',
        type: 'POST',
        data: JSON.stringify(objdata),
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('data saved');
            $("#usermodal").modal('hide');
        },
        error: function (error) {
            alert('data can\'t be saved');
        }
    });
};
