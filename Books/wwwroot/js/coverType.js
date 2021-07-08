var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/CoverType/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "coverTypeId",
                "render": function(data){
                    return `<div class="text-center">
                                        <a href="/Admin/CoverType/Update/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                            <i class="fas fa-edit"></i> Edit
                                        </a>
                                        <a  onclick = Delete("/Admin/CoverType/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                            <i class="fas fa-trash"></i> Delete
                                        </a>
                                    </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No data available"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this data",
        icon: "warning",
        buttons: [true, "Delete"],
        dangerMode: true
    }).then((response) => {
        if (response) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}