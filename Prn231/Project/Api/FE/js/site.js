var currentIndex = 0;
var acc = localStorage.getItem('accountId');
var key = localStorage.getItem('key');
var student;
var questions;


$(document).ready(() => {
    getQuestions();
    getStudent();
    getCourse();
    countDown();
});

var countDown = () => {

    var minutes = 1;
    var seconds = 0;

    var countdownInterval = setInterval(function () {
        if (minutes === 0 && seconds === 0) {
            clearInterval(countdownInterval);
            $('#count_down').text("Time Left 0:0");
            // submit();
        } else {
            if (seconds === 0) {
                minutes--;
                seconds = 59;
            } else {
                seconds--;
            }
            $('#count_down').text("Time Left " + minutes + ":" + seconds.toString().padStart(2, '0'))
        }
    }, 1000);
}



var getStudent = () => {
    $.ajax({
        url: `http://localhost:5024/api/Accounts/${acc}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { student = data; $('#student').text('Student Name : ' + data.fullName) },
        error: () => alert("Error"),
    });
}

var getCourse = () => {
    $.ajax({
        url: `http://localhost:5024/api/Keys/${key}`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => { student = data; $('#course').text('Coure : ' + data) },
        error: () => alert("Error"),
    });
}

var getQuestions = () => {
    $.ajax({
        url: `http://localhost:5024/api/Questions?filter=keyId eq '${key}'`,
        type: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        success: (data) => {
            questions = data;
            modifiedData(questions);
            
            // loadPaging(questions);
        },
        error: () => alert("Error"),
    });
}

function generateRandomNumbers(lowerBound) {
    var randomNum1 = Math.floor(Math.random() * lowerBound);
    var randomNum2 = randomNum1;

    while (randomNum2 === randomNum1) {
        randomNum2 = Math.floor(Math.random() * lowerBound);
    }

    return [randomNum1, randomNum2];
}

function modifiedData(questions) {
    $.each(questions, (index, question) => {
        var randomNumbers = generateRandomNumbers(question.listAnswer.length);
        var temp = question.listAnswer[randomNumbers[0]];
        question.listAnswer[randomNumbers[0]] = question.listAnswer[randomNumbers[1]];
        question.listAnswer[randomNumbers[1]] = temp;
    })
    for (var i = 0; i < questions.length; i++) {
        var randomQuestion = generateRandomNumbers(questions.length);
        var temp = questions[randomQuestion[0]];
        questions[randomQuestion[0]] = questions[randomQuestion[1]];
        questions[randomQuestion[1]] = temp;
    }
    loadDataTable(questions);
}

var moveQuestion = (index) => {
    currentIndex = index;
    loadDataTable(questions);
}

var loadPaging = (data) => {
    $('#paging').empty();
    data.forEach(item => {
        var index = item.questionId - 1;
        var html = `<div onclick='moveQuestion(${index})' class="btn-primary paging">${item.questionId}</div>`;
        $('#paging').append(html);
    });
};


var loadDataTable = (questions) => {
    var currentQuestion = questions[currentIndex];

    $("#numberAnswer").text(`There are ${questions.length} questions and your progress of answering is`);
    $("#idAnswers").text('Questions ' + (currentIndex + 1));
    $("#numberAnswers").text(currentQuestion.numberRightAnswer);
    $("#questionContent").text(currentQuestion.content);
    $("#checkboxList").empty();


    if (currentQuestion.numberRightAnswer == 1) {
        $.each(currentQuestion.listAnswer, (index, item) => {
            var checkbox = $("<input>").attr({
                type: 'radio',
                id: item.content,
                checked: item.ticked,
                name: currentQuestion.content
            }).change(function (event) {
                item.ticked = event.target.checked;
                updateProgress();
            });
            var label = $("<label>").attr({
                for: item.content,
            }).text(item.content);
            $("#checkboxList").append(checkbox, label, $("<br>"));
        });
    } else {
        $.each(currentQuestion.listAnswer, (index, item) => {
            var checkbox = $("<input>").attr({
                type: 'checkbox',
                id: item.content,
                checked: item.ticked,
            }).change(function (event) {
                item.ticked = event.target.checked;
                updateProgress();
            });
            var label = $("<label>").attr({
                for: item.content,
            }).text(item.content);
            $("#checkboxList").append(checkbox, label, $("<br>"));
        });
    }

}

function handleBackButtonClick() {
    if (currentIndex > 0) {
        currentIndex--;
        loadDataTable(questions);
        $("#nextButton").prop("disabled", false);
    }
    if (currentIndex === 0)
        $("#backButton").prop("disabled", true);
}

function handleNextButtonClick() {
    if (currentIndex < questions.length - 1) {
        currentIndex++;
        loadDataTable(questions);
        $("#backButton").prop("disabled", false);
    }
    if (currentIndex === questions.length - 1)
        $("#nextButton").prop("disabled", true);
}

function updateProgress() {
    const totalQuestions = questions.length;
    const tickedQuestions = questions.filter(q => q.listAnswer.some(answer => answer.ticked)).length;
    const percentage = (tickedQuestions / totalQuestions) * 100;

    $('#progress-bar').css('width', percentage + '%');
    $('#progress-bar').text(percentage.toFixed(0) + '%');
}

var che;
var submit = () => {
    questions.sort((a, b) => a.questionId - b.questionId);
    
    var exam = {
        accountId: acc,
        keyId: key,
        examAnswers: questions.map(element => ({
            examAnswer1: element.questionId,
            rightRightAnswer: element.listAnswer
                .map((answer, index) => answer.ticked ? `/${answer.id}` : '')
                .join('').substring(1)
        }))
    };
    che = JSON.stringify(exam);
    onsubmit(exam);
};

var onsubmit = (exam) => $.ajax({
    url: `http://localhost:5024/api/Questions`,
    type: 'POST',
    headers: {
        "Content-type": "application/json"
    },
    data: JSON.stringify(exam),
    success: () => {
        localStorage.removeItem("key");
        localStorage.removeItem("accountId");
        localStorage.setItem("course", $('#course').text());
        localStorage.setItem("name", $('#student').text());
        localStorage.setItem("time", $('#count_down').text());
        location.href = 'success.html';
    },
    error: () => { alert('error'); console.error(); }
});
