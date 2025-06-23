let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblRoles').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        responsive: true,
        "ajax": {
            "url": "/Admin/Role/GetAll"
        },
        "columns": [
            { data: "name" },
            { data: "roleDescription" },
            {
                "data": "id",
                "render": function (data) {
                    
                    return `
                        <div class="text-center d-flex justify-content-between">
                            <a  
                                href="/Admin/Role/Upsert/${data}"
                                class="btn btn-success text-white"
                                style="cursor:pointer"
                               >
                                <i class="bi bi-pencil-square"></i>  
                            </a>

                            <a
                                class="btn btn-danger text-white"
                                style="cursor:pointer"
                                onclick=Delete("${data}")
                              >
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>
                    `
                }
            }
        ]
    })
}

function Delete(id) {
    swal({
        title: "¿Estás seguro de eliminar este rol?",
        text: "Este registro no podrá ser recuperado",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((isDelete) => {
        if (isDelete) {
            fetch("/Admin/Role/Delete", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(id) // manda como string JSON
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error en la solicitud');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                })
                .catch(error => {
                    console.error("Error al eliminar:", error);
                    toastr.error("Error al comunicarse con el servidor.");
                });
        }
    });
}

