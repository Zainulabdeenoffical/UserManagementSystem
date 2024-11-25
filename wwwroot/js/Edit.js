function update(id) {
    
    $.ajax({
        url: '/user/update?id=' + id,
        type: 'Get',
        contentType:'application/json; charset=utf-8',
         datatype: 'json',
        success: function (response) {

            $('#Editmodel').modal('show');
            $('#userid').val(response.userid);
            $('#fname').val(response.fname);
            $('#lname').val(response.lname);
            $('#em').val(response.em);
        },

        Error: function () {
            alert('data not found ');
        }

    })

    
}
function update_fun() {
    var updateobj = {
        id: $('#userid').val(),
        first_name: $('#fname').val(),
        last_name: $('#lname').val(),
        email: $('#em').val()
    };
    $.ajax({
        url: '/user/update_meth',
        type: 'POST',
        data: JSON.stringify(updateobj),
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('data saved');
            $("#usermodal").modal('hide');
           
            GetUserList();
            location.reload();
        },
        error: function (error) {
            alert('data can\'t be saved');
        }
    });

}