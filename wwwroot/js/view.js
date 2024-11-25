$(document).ready(function () {
    GetUserList();
});


function GetUserList() {
    $.ajax({
        url: '/user/GetUserList',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            OnSuccess(response);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching user list:", status, error);
        }
    });
}

function OnSuccess(response) {
    $('#UserTable').DataTable({
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bFilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'id',
                render: function (data, type, row, meta) {
                    return row.id;;
                }
            },
            {
                data: 'first_name',
                render: function (data, type, row, meta) {
                    return row.first_name;
                }
            },
            {
                data: 'last_name',
                render: function (data, type, row, meta) {
                    return row.last_name;
                }
            },
            {
                data: 'email',
                render: function (data, type, row, meta) {
                    return row.email; 
                }
            }
        ]
    });
}
