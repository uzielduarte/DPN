let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblUsers').DataTable({
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
            "url" :"/Admin/User/GetAll"
        },
        "columns": [
            { data: "email" },
            { data: "firstName" },
            { data: "lastName" },
            { data: "phoneNumber" },
            { data: "role" },
            {
                "data": {
                    id:"id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    let today = new Date().getTime();
                    let lock = new Date(data.lockoutEnd).getTime();
                    let btnLock = '';
                    let btnRoles = `
                        <a class="btn btn-warning btn-sm shadow-none"
                           href="/Admin/User/Roles/${data.id}">
                           <i class="bi bi-card-checklist"></i> Roles
                        </a>
                    `
                    let btnDelete = `
                                <a
                                    onclick=Delete("/Admin/User/Delete/${data.id}")
                                    class="btn btn-danger text-white"
                                    style="cursor:pointer"
                                >
                                    <i class="bi bi-trash-fill"></i>
                                </a>
                    `;

                    if (lock > today) {
                        btnLock = `
                            
                                <a
                                    class="btn btn-danger text-white"
                                    style="cursor:pointer"
                                    onclick=LockUnlock('${data.id}')
                                >
                                    <i class="bi bi-unlock-fill"></i>Desbloquear
                                </a>
                            
                        `
                    }
                    else {
                        btnLock = `
                            
                                <a
                                    class="btn btn-success text-white"
                                    style="cursor:pointer"
                                    onclick=LockUnlock('${data.id}')
                                >
                                    <i class="bi bi-lock-fill"></i>Bloquear
                                </a>
                            
                        `
                    }

                    return `
                        <div class="text-center d-flex justify-content-between">
                            ${btnRoles}
                            ${btnLock}
                            ${btnDelete}
                        </div>
                    `
                    
                }
            }
        ]
    })
}

function LockUnlock(id)
{
    fetch('/Admin/User/LockUnlock', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(id)
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
            console.error('Error:', error);
            toastr.error("Error al comunicarse con el servidor.");
        });
}

function Delete(url) {
    swal({
        title: "Estás seguro de elimiar al usuario",
        text: "Este usuario no podra ser recuperado",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((isDelete) => {
        if (isDelete) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                        datatable.ajax.reload()
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}