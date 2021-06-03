function LoadLis() {
    $("#listado").DataTable({
        "language":
        {
            "processing": "<div class=''><i class='fa fa-cog fa-spin site-loader-color'></i></div>",
            "search": "Filtro:",
        },
        "filter": true,
        "ajax": {
            "url": "/api/PassengerApi",
            "type": "GET",
            "dataSrc": ''
        },
        "columnDefs":
            [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                },
                {
                    "render": function (data, type, full, meta) {
                        return '<div class="btn-group btn-group-sm" role="group" aria-label="Basic mixed styles example"><button type="button" class="btn btn-danger" onclick="Delete(\'' + full.id + '\');return false;"><i class="fa fa-remove"></i></button><button type="button" class="btn btn-success" onclick="GetData(\'' + full.id + '\');return false;"><i class="fa fa-edit"></i></button></div>'
                    },
                    "targets": [5],
                },
                { "searchable": true, "targets": [1, 2, 3, 4] },
                { "className": "text-center", "targets": [1, 2, 3, 4] }
            ],
        "columns": [
            { "data": "id", "name": "id", "autoWidth": true },
            { "data": "identityCard", "name": "identityCard", "autoWidth": true },
            { "data": "name", "name": "name", "autoWidth": true },
            { "data": "address", "name": "address", "autoWidth": true },
            { "data": "telephone", "name": "telephone", "autoWidth": true },
        ],
        "dom": "<'row'<'col-sm-6'l><'col-sm-6'<'#buttonContainer.site-datatable-button-container'>f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-5'i><'col-sm-7'p>>",
    });
    $("#buttonContainer")
        .addClass("pull-right")
        .append(" <button type='button' class='btn btn-sm btn-primary' data-bs-toggle='modal' data-bs-target='#passengerAddPartial'><i class='fa fa-file-text-o'></i></button>");
}

function Update() {
    var id = $('#inputIdEdit').val();
    var identityCard = $('#txtIdentityCardEdit').val();
    var name = $('#txtNameEdit').val();
    var address = $('#txtAddressEdit').val();
    var telephone = $('#txtTelephoneEdit').val();

    var data = JSON.stringify({

        IdentityCard: identityCard,
        Name: name,
        Address: address,
        Telephone: telephone
    });

    $.ajax({
        type: "PUT",
        url: "/api/PassengerApi/" + id,
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#passengerEditPartial').modal('hide');
                Success('Guardado Exitosamente!..');
                $("#listado").DataTable().ajax.reload();
            } else {
                Errors('Se produjo un Error al Intentar Guardar');
            }
        },
        error: function (xhr, status, error) {
            console.log(xhr)
        }
    });
}

function Add() {
    var identityCard = $('#txtIdentityCard').val();
    var name = $('#txtName').val();
    var address = $('#txtAddress').val();
    var telephone = $('#txtTelephone').val();

    var data = JSON.stringify({
        IdentityCard: identityCard,
        Name: name,
        Address: address,
        Telephone: telephone
    });

    $.ajax({
        type: "POST",
        url: "/api/PassengerApi",
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#passengerAddPartial').modal('hide');
                $("#listado").DataTable().ajax.reload();
                Success('Guardado Exitosamente!..');
            } else {
                Errors('Se produjo un Error al Intentar Guardar');
            }
        },
        error: function (xhr, status, error) {
            console.log(xhr)
        }
    });
}

function GetData(id) {
    $.ajax({
        type: "GET",
        url: "/api/PassengerApi/" + id,
        success: function (result) {
            $('#inputIdEdit').val(result.id);
            $('#txtIdentityCardEdit').val(result.identityCard);
            $('#txtNameEdit').val(result.name);
            $('#txtAddressEdit').val(result.address);
            $('#txtTelephoneEdit').val(result.telephone);
            $('#passengerEditPartial').modal('show');
        }
    });
}

function Delete(id)
{
    $.ajax({
        type: "GET",
        url: "/api/PassengerApi/" + id,
        success: function (result) {
            Swal.fire({
                title: 'Esta seguro de eliminar a?',
                text: result.name + "!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Si!',
                cancelButtonColor: '#d33',
                cancelButtonText: 'No'
                
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "DELETE",
                        url: "/api/PassengerApi/" + id,
                        success: function (result) {
                            if ($.trim(result)) {
                                $("#listado").DataTable().ajax.reload();
                                Success('Se ha eliminado con exito.');
                            }
                        }
                    });
                }
            });
        }
    });
}