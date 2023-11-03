var director;

$(document).ready(() => {


});


var getDirector = () => {
    $.ajax({
        url: `http://localhost:5000/api/Director/GetDirectors/${$('#nationality').val()}/${$('#gender').val()}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { director = data; },
        error: () => alert("Error"),
    });
}