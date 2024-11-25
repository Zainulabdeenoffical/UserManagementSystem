function update(id) {
    
    $.ajax({
        url: '/user/update?id=' + id,
        type: 'Get',
        contentType:'application/json; charset=utf-8',
         datatype: 'json',
        success: function (response) {

            $('#Editmodel').modal('show');
            $('#userid').val(response.userid);
            $('#First_name').val(response.First_name);
            $('#Last_name').val(response.Last_name);
            $('#Email').val(response.Email);
        },

        Error: function () {
            alert('data not found ');
        }

    })

    
}