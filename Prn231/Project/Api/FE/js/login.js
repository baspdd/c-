var check = 0;

$(document).ready(() => {

});

var notice = (id, content) => $(`#${id}`).text(content);

// var anyKey = (key) => {
//     $.ajax({
//         url: `http://localhost:5024/api/Keys/key?key=${key}`,
//         type: "GET",
//         headers: {
//             "Content-Type": "application/json",
//         },
//         success: (data) => { check1 = data; if (!data) $('#key_danger').text("Key is not valid"); },
//         error: () => { alert("Error"); },
//     });
// }

var anyAccount = (acc, pass, key) => {
    $.ajax({
        url: `http://localhost:5024/api/Accounts?acc=${acc}&pass=${pass}&key=${key}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { check = data },
        error: () => { alert("Error"); },
    });
}

var testAsign = () => {
    notice('key_danger', '');
    notice('account_danger', '');

    anyAccount($('#account').val(), $('#pass').val(), $('#key').val())
    switch (check) {
        case 1:
            $('#key_danger').text("Key is not valid");
            break;
        case 2:
            $('#account_danger').text("Account is not valid");
            break;
        case 3:
            $('#login_danger').text("You already log this exam");
            break;
        case 4:
            localStorage.setItem("key", $('#key').val());
            localStorage.setItem("accountId", $('#account').val());
            location.href = 'index.html';
            break;
        default:
            break;
    }
}

