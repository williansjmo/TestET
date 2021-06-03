function LoadList() {
    var groupColumn = 1;
    $("#listado").DataTable({
        "filter": true,
        "ajax": {
            "url": "/api/TravellerApi",
            "type": "GET",
            "dataSrc": ''
        },
        "columnDefs":
            [
                {
                    "targets": [0,1],
                    "visible": false,
                    "searchable": false
                },
                {
                    "render": function (data, type, full, meta) {
                        return '<div class="btn-group btn-group-sm" role="group" aria-label="Basic mixed styles example"><button type="button" class="btn btn-danger" onclick="DeleteTraveller(\'' + full.id + '\');return false;"><i class="fa fa-remove"></i></button><button type="button" class="btn btn-success" onclick="GetTraveller(\'' + full.id + '\');return false;"><i class="fa fa-edit"></i></button></div>'
                    },
                    "targets": [3],
                },
                { "searchable": true, "targets": [2] },
                { "className": "text-center", "targets": [2] }
            ],
        "order": [[groupColumn, 'asc']],
        "drawCallback": function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;

            api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                if (last !== group) {
                    $(rows).eq(i).before(
                        '<tr class="group"><td colspan="5"> Destino: ' + group + '</td></tr>'
                    );
                    last = group;
                }
            });
        },
        "columns": [
            { "data": "id", "name": "id", "autoWidth": true },
            { "data": "destination", "name": "destination", "autoWidth": true },
            { "data": "name", "name": "name", "autoWidth": true },
        ],
        "dom": "<'row'<'col-sm-6'l><'col-sm-6'<'#buttonContainer.site-datatable-button-container'>f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-5'i><'col-sm-7'p>>",
    });
    $("#buttonContainer")
        .addClass("pull-right")
        .append(" <button type='button' id='btnModalTraveller' class='btn btn-sm btn-primary' data-bs-toggle='modal' data-bs-target='#travellerAddPartial'><i class='fa fa-file-text-o'></i></button>");
}



function AddTraveller()
{
    var passengerId = $('#inputPassengerId').val();
    var travelId = $('#inputTravelId').val();

    var data = JSON.stringify({
        PassengerId: passengerId,
        TravelId: travelId
    });

    $.ajax({
        type: "POST",
        url: "/api/TravellerApi",
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#travellerAddPartial').modal('hide');
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

function UpdateTraveller() {
    var id = $('#inputTravellerId').val();
    var passengerId = $('#inputPassengerId').val();
    var travelId = $('#inputTravelId').val();

    var data = JSON.stringify({
        PassengerId: passengerId,
        TravelId: travelId
    });

    $.ajax({
        type: "PUT",
        url: "/api/TravellerApi/"+ id,
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#travellerAddPartial').modal('hide');
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

function DeleteTraveller(id) {
    $.ajax({
        type: "GET",
        url: "/api/TravellerApi/" + id,
        success: function (result) {
            Swal.fire({
                title: 'Esta seguro de eliminar el viaje?',
                text: 'Con destino a: ' + result.destination + ', y el pasajero: ' + result.name + '!',
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
                        url: "/api/TravellerApi/" + id,
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

function GetTraveller(id) {
    $.ajax({
        type: "GET",
        url: "/api/TravellerApi/" + id,
        success: function (result) {
            $('#inputTravellerId').val(result.id);
            $('#inputPassengerId').val(result.passengerId);
            $('#inputTravelId').val(result.travelId);
            $('#txtIdentityCard').val(result.identityCard);
            $('#txtName').val(result.name);
            $('#txtTravelCode').val(result.travelCode);
            $('#txtNumberOfSeats').val(result.numberOfSeats);
            $('#txtDestination').val(result.destination);
            $('#txtPlaceOfOrigin').val(result.placeOfOrigin);
            $('#txtPrice').val(result.price);
            $('#travellerAddPartial').modal('show');
        },
        error: function (xhr, status, error) {
            console.log(xhr);
            Errors(xhr);
        }
    });
}

function GetPassengerIdentityCard(IdentityCard) {
    $.ajax({
        type: "GET",
        url: "/api/PassengerApi/GetPassengerIdentityCard/" + IdentityCard,
        success: function (result) {
            $('#inputPassengerId').val(result.id);
            $('#txtName').val(result.name);
        },
        error: function (xhr, status, error) {
            console.log(xhr);
            Errors('Error de consulta!');
        }
    });
}

function GetTravelCode(TravelCode) {
    $.ajax({
        type: "GET",
        url: "/api/TravelApi/GetTravelCode/" + TravelCode,
        success: function (result) {
            $('#inputTravelId').val(result.id);
            $('#txtNumberOfSeats').val(result.numberOfSeats);
            $('#txtDestination').val(result.destination);
            $('#txtPlaceOfOrigin').val(result.placeOfOrigin);
            $('#txtPrice').val(result.price);
        },
        error: function (xhr, status, error) {
            console.log(xhr);
            Errors('Error de consulta!');
        }
    });
}
            
function ClearDataPassenger()
{
    $('#inputPassengerId').val('');
    $('#txtName').val('');
}

$('#txtIdentityCard').keypress(function (e) {
    if (e.keyCode == 13) {
        ClearDataPassenger();
        GetPassengerIdentityCard($(this).val());
        e.preventDefault();
    }
});

$('#txtTravelCode').keypress(function (e) {
    if (e.keyCode == 13) {
        GetTravelCode($(this).val());
        e.preventDefault();
    }
});

$('#btnAddTraveller').click(function (e) {
    if ($('#inputTravelId').val() == '') {
        AddTraveller();
        ClearTraveller();
    }
    else {
        UpdateTraveller();
        ClearTraveller();
    }
});

$('#btnCloseTraveller').click(function () {
    $('#travellerAddPartial').modal('hide');
    ClearTraveller();
});

function ClearTraveller() {
    $(':input').val('');
}
