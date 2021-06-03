function LoadTravelList() {
    $("#listado").DataTable({
        "filter": true,
        "ajax": {
            "url": "/api/TravelApi",
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
                        return '<div class="btn-group btn-group-sm" role="group" aria-label="Basic mixed styles example"><button type="button" class="btn btn-danger" onclick="DeleteTravel(\'' + full.id + '\');return false;"><i class="fa fa-remove"></i></button><button type="button" class="btn btn-success" onclick="GetTravel(\'' + full.id + '\');return false;"><i class="fa fa-edit"></i></button></div>'
                    },
                    "targets": [6],
                },
                { "searchable": true, "targets": [1, 2, 3, 4, 5] },
                { "className": "text-center", "targets": [1, 2, 3, 4, 5] }
            ],
        "columns": [
            { "data": "id", "name": "id", "autoWidth": true },
            { "data": "travelCode", "name": "travelCode", "autoWidth": true },
            { "data": "numberOfSeats", "name": "numberOfSeats", "autoWidth": true },
            { "data": "destination", "name": "destination", "autoWidth": true },
            { "data": "placeOfOrigin", "name": "placeOfOrigin", "autoWidth": true },
            { "data": "price", "name": "price", "autoWidth": true },
        ],
        "dom": "<'row'<'col-sm-6'l><'col-sm-6'<'#buttonContainer.site-datatable-button-container'>f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-5'i><'col-sm-7'p>>",
    });
    $("#buttonContainer")
        .addClass("pull-right")
        .append(" <button type='button' class='btn btn-sm btn-primary' data-bs-toggle='modal' data-bs-target='#travelAddPartial'><i class='fa fa-file-text-o'></i></button>");
}

function AddTravel() {
    var travelCode = $('#txtTravelCode').val();
    var numberOfSeats = $('#txtNumberOfSeats').val();
    var destination = $('#txtDestination').val();
    var placeOfOrigin = $('#txtPlaceOfOrigin').val();
    var price = $('#txtPrice').val();

    var data = JSON.stringify({
        TravelCode: travelCode,
        NumberOfSeats: numberOfSeats,
        Destination: destination,
        PlaceOfOrigin: placeOfOrigin,
        Price: price
    });

    $.ajax({
        type: "POST",
        url: "/api/TravelApi",
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#travelAddPartial').modal('hide');
                ClearTravel();
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

function UpdateTravel() {
    var id = $('#inputTravelId').val();
    var travelCode = $('#txtTravelCode').val();
    var numberOfSeats = $('#txtNumberOfSeats').val();
    var destination = $('#txtDestination').val();
    var placeOfOrigin = $('#txtPlaceOfOrigin').val();
    var price = $('#txtPrice').val();

    var data = JSON.stringify({
        TravelCode: travelCode,
        NumberOfSeats: numberOfSeats,
        Destination: destination,
        PlaceOfOrigin: placeOfOrigin,
        Price: price
    });

    $.ajax({
        type: "PUT",
        url: "/api/TravelApi/" + id,
        data: data,
        contentType: "application/json",
        processData: false,
        success: function (result) {
            if ($.trim(result)) {
                $('#travelAddPartial').modal('hide');
                ClearTravel();
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

function GetTravel(id) {
    $.ajax({
        type: "GET",
        url: "/api/TravelApi/" + id,
        success: function (result) {
            $('#inputTravelId').val(result.id);
            $('#txtTravelCode').val(result.travelCode);
            $('#txtNumberOfSeats').val(result.numberOfSeats);
            $('#txtDestination').val(result.destination);
            $('#txtPlaceOfOrigin').val(result.placeOfOrigin);
            $('#txtPrice').val(result.price);
            $('#travelAddPartial').modal('show');
        },
        error: function (xhr, status, error) {
            console.log(xhr);
            Errors(xhr);
        }
    });
}

function DeleteTravel(id) {
    $.ajax({
        type: "GET",
        url: "/api/TravelApi/" + id,
        success: function (result) {
            Swal.fire({
                title: 'Esta seguro de eliminar el viaje?',
                text: result.destination + "!",
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
                        url: "/api/TravelApi/" + id,
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

$('#btnAddTravel').click(function () {
    if ($('#inputTravelId').val() == '') {
        AddTravel();
    }
    else {
        UpdateTravel();
    }
});
$('#btnCloseTravel').click(function () {
    $('#travelAddPartial').modal('hide');
    ClearTravel();
});

function ClearTravel() {
    $(':input').val('');
}