$(document).ready(() => {
    getCourse();
    // if (valid == 0){
    //     $('#login-container').hide();
    //     $('#exams').show();
    // }
});

var check;
var courseID;

var getCourse = () => {
    $.ajax({
        url: `http://localhost:5024/api/Courses?$filter=contains(CourseName, '${$('#search').val()}')`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => loadCourse(data),
        error: () => alert("Error"),
    });
}

//courseId
var loadCourse = (data) => {
    $('#listCourse').empty();
    data.forEach(item => {
        var html = `<div onclick="getKeys(${item.courseId})" class="course">${item.courseName}</div>`;
        $('#listCourse').append(html);
    });
};


function handleFileChange(input) {
    var file = input.files[0];
    readXlsxFile(file).then(function (data) {

        const hash_data = ['Question', 'Answer', 'RightAnswer']
        const indices = [];
        var rowStart = 0;

        data.forEach((row, rowIndex) => {
            if (row[0] == 'Stt') rowStart = rowIndex;
            row.forEach((item, celIndex) => {
                if (hash_data.includes(item)) indices.push(celIndex);
            });
        });

        var questions = [];
        data.forEach((row, rowIndex) => {
            if (rowIndex > rowStart) {
                var ans = rightans = '';
                row.forEach((cell, celIndex) => {
                    if (cell) {
                        if (celIndex >= indices[1] && celIndex < indices[2]) ans += '/' + cell;
                        else if (celIndex >= indices[2]) rightans += '/' + cell;
                    }
                });
                questions.push({
                    questionId: row[0],
                    keyId: data[0][1],
                    content: row[indices[0]],
                    answer: ans.substring(1),
                    rightAnswer: rightans.substring(1),
                    // "numberRightAnswer": 0
                });
            }
        });

        var excel = {
            keyId: data[0][1],
            courseId: courseID,
            questions: questions,
        };

        $.ajax({
            url: `http://localhost:5024/api/Keys`,
            type: 'POST',
            headers: {
                "Content-type": "application/json"
            },
            data: JSON.stringify(excel),
            success: () => getKeys(courseID),
            error: () => { alert('error'); console.error(); }
        });
    });
}

var getKeys = (id) => {
    courseID = id;
    $.ajax({
        url: `http://localhost:5024/api/Keys?$filter=CourseId eq ${id}&select=keyId`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { loadKey(data); },
        error: () => alert("Error"),
    });
}

var loadKey = (data) => {
    $('#keys').fadeIn();
    $('#listKey').empty();
    data.forEach(item => {
        var html = `<div onclick="getExam('${item.KeyId}')" class="course">${item.KeyId}</div>`;
        $('#listKey').append(html);
    });
};


var getExam = (id) => {
    $('#generate').val(id);
    $.ajax({
        url: `http://localhost:5024/api/Questions/${id}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { loadTable(data); },
        error: () => alert("Error"),
    });
}


var loadTable = (data) => {
    $('#score').fadeIn();
    $('#table').empty();
    data.forEach(item => {
        var html = `
        <tr>
            <td>${item.examId}</td>
            <td>${item.accountName}</td>
            <td>${item.score}</td>
            <td><button class="btn btn-primary" onclick="deleteProduct(${item.examId})">Re-Asign</button></td>
        </tr>`;
        $('#table').append(html);
    });
};


var deleteProduct = (id) => $.ajax({
    url: `http://localhost:5024/api/Questions/${id}`,
    type: 'DELETE',
    headers: {
        "Content-type": "application/json"
    },
    success: () => {},
    error: () => { alert('error'); }
});


var generate = () => {
    $.ajax({
        url: `http://localhost:5024/api/Questions/gen/${$('#generate').val()}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { exportExcel(data); },
        error: () => alert("Error"),
    });
}


var exportExcel = (formal) => {
    var header = [
        {
            type: String,
            value: 'Student ID',
            fontWeight: 'bold'
        },
        {
            type: String,
            value: 'Student Name',
            fontWeight: 'bold'
        },
        {
            type: String,
            value: 'Key of Course',
            fontWeight: 'bold'
        },
        {
            type: String,
            value: 'Score',
            fontWeight: 'bold'
        }
    ];
    var arrayOfArrays = formal.map(item => [
        {
            type: String,
            value: item.accountId,
        },
        {
            type: String,
            value: item.accountName,
        },
        {
            type: String,
            value: item.keyId,
        },
        {
            type: String,
            value: item.score
        },
        // item.examAnswers.map(answer => answer.rightRightAnswer)
    ]);

    arrayOfArrays.unshift(header);
    check = arrayOfArrays;
    writeXlsxFile(arrayOfArrays, {
        fileName: 'file.xlsx'
    })
}

var valid = 2;
var anyAccount = (acc, pass) => {
    $.ajax({
        url: `http://localhost:5024/api/Accounts/Staff?acc=${acc}&pass=${pass}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { valid = data },
        error: () => { alert("Error"); },
    });
}

var testAsign = () => {
    anyAccount($('#account').val(), $('#pass').val())
    switch (valid) {
        case 1:
            $('#login_danger').text("account is not valid");
            break;
        case 0:
            $('#login-container').hide();
            $('#exams').show();
            break;
        default:
            break;
    }
}

