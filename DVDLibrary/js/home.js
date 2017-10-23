$(document).ready(function () {
    loadMovies();
    $('#create-dvd-button').on('click', function () {
        $('#addMovieFormDiv').toggle('slow');
        $('#dvdTableDiv').hide();
        $('editMovieFormDiv').hide();
    });

    $('#add-movie-button').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#addMovieFormDiv').find('input'));

        if (haveValidationErrors) {
            return false;
        }
        if ($('#add-movie-realeaseYear').val().length != 4) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("The release year must be in the YYYY format."));
            return false;
        }
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
                var dvdid = dvd.dvdid;

                var row = '<tr>';
                row += '<td>' + title + '</td>';
                row += '<td>' + realeaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a onclick = "showEditForm()">Edit</a> | <a onclick ="deleteMovie(' + dvdid + ')">Delete</a></td>';
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
function deleteMovie() {
    var deleteMovie = confirm("Are you sure you want to delete this DVD from the collection?");
    if (deleteMovie = true) {
        function deleteMovieFromCollection(dvdid) {
            $.ajax({
                type: "DELETE",
                url: 'http://localhost:8080/dvd/' + dvdid,
                success: function (status) {
                    loadContacts();
                }
            });
        }
    }
}
function clearMoviesTable() {
    $('#contentRows').empty();
}
function showEditForm() {
    $('#errorMessages').empty();

    $('#dvdTableDiv').hide();
    $('#editMovieFormDiv').show();
}
function hideEditMovieForm() {
    $('#dvdTableDiv').show();
    $('#editMovieFormDiv').hide();
}
function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function () {
        // Use the HTML5 validation API to find the validation errors
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}