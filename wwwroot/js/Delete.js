$('#DeleteAll').on('click', function () {
    let checkboxes = document.getElementsByTagName('input');
    let val = null;
    for (let i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].type === 'checkbox') {
            if (val === null) {
                val = checkboxes[i].checked;
            } else {
                checkboxes[i].checked = val;
            }
        }
    }
});

$('#Select_Delete').on('click', function () {
    
    
    let val = [];
    $(':checkbox:checked').each(function (i) {
        val[i] = $(this).val();
    });
    $.ajax({
        type: 'POST',
        url: '/user/DeleteAll',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'Success') {
                location.reload();
            }
        },
        Error: function () {
            alert('Data cant be deleted');
        }

    });
});
// Delete with using single button

function Delete_btn(id) {
    $.ajax({

        url: '/user/Delete_btn?id=' + id,
         type: 'DELETE',
        success: function () {
            alert('Data Deleted Succesfully');
            GetUserList()
            location.reload();
        },
        error: function () {
            alert('Data cant be Deletd');
        }



    });
} 




