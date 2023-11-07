var director, movies;

$(document).ready(() => {

});


var getDirector = () => {
    $.ajax({
        url: `http://localhost:5000/api/Director/GetDirectors/${$('#nationality').val()}/${$('#gender').val()}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { director = data; loadData(data) },
        error: () => alert("Error"),
    });
}


var loadData = (data) => {
    $('#body').empty();
    data.forEach(item => {
        var json = JSON.stringify(item);
        var html = `<tr onclick='getMovies(${item.id})'>
        <td>${item.id}</td>
        <td>${item.fullName}</td>
        <td>${item.male}Male</td>
        <td>${item.dob}Dob</td>
        <td>${item.nationality}Nationality</td>
        <td>${item.description}Description</td>
        </tr>`;
        $('#body').append(html);
    });
};

var getMovies = (id) => {
    $.ajax({
        url: `http://localhost:5000/api/Director/GetDirectors/${id}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { movies = data; },
        error: () => alert("Error"),
    });
}