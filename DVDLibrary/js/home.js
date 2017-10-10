$(document).ready(function () {
    loadMovies();
    $('#create-dvd-button').on('click', function () {
        $('#addMovieFormDiv').toggle('slow');
        $('#dvdTableDiv').hide();
    });
    $('#add-movie-button').click(function (event) {

        $.ajax({
            type: 'POST',
            url: 'http://localhost:8080/dvd',
            data: JSON.stringify({
                title: $('#add-movie-title').val(),
                realeaseYear: $('#add-movie-realeaseYear').val(),
                director: $('#add-movie-director').val(),
                rating: $('#add-movie-rating').val(),
                notes: $('#add-movie-notes').val(),
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty
                $('#add-movie-title').val('');
                $('#add-movie-realeaseYear').val('');
                $('#add-movie-director').val('');
                $('#add-movie-rating').val('');
                $('#add-movie-notes').val('');
                loadMovies();



            },
            error: function (jpXHR, textStatus, errorThrown) {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling webservice. Please try again later.'));

            }
        })
    });
});
function hideAddMovieForm() {
    $('#dvdTableDiv').show();
    $('#addMovieFormDiv').hide();
}
function loadMovies() {
    clearMoviesTable();
    var contentRows = $('#contentRows');
    $('#addMovieFormDiv').hide();
    $('#dvdTableDiv').show();
    $('#editMovieFormDiv').hide();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var realeaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;

                var row = '<tr>';
                row += '<td>' + title + '</td>';
                row += '<td>' + realeaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a onclick = "showEditForm()">Edit</a> | <a>Delete</a></td>';
                row += '</tr>';

                contentRows.append(row);
            });
        },
        error: function (jpXHR, textStatus, errorThrown) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling webservice. Please try again later.'));

        }
    });
}
function clearMoviesTable() {
    $('#contentRows').empty();
}
function showEditForm() {
$('#errorMessages').empty();

$('#dvdTableDiv').hide();
$('#editMovieFormDiv').show();
}