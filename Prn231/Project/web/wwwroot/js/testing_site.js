document.addEventListener("DOMContentLoaded", function () {
    var checkboxList = document.getElementById('checkboxList');
    var numberAnswers = document.getElementById('numberAnswers');
    var questionContent = document.getElementById('questionContent');
    var backButton = document.getElementById('backButton');
    var nextButton = document.getElementById('nextButton');

    var questions = @Html.Raw(JsonConvert.SerializeObject(Model));
    var currentIndex = 0;

    function updateQuestion() {
        var currentQuestion = questions[currentIndex];
        numberAnswers.textContent = currentQuestion.numberRightAnswer;
        questionContent.textContent = currentQuestion.Content;
        while (checkboxList.firstChild) checkboxList.empty();
        currentQuestion.listAnswer.forEach(item => {
            var checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkbox.id = item.Content;
            checkbox.checked = item.Ticked;
            checkbox.onchange = function (event) {
                item.Ticked = event.target.checked;
            };
            checkbox.name = item.Content;
            var label = document.createElement('label');
            label.htmlFor = item.Content;
            label.appendChild(document.createTextNode(item.Content));
            checkboxList.appendChild(checkbox);
            checkboxList.appendChild(label);
            checkboxList.appendChild(document.createElement('br'));
        });
    }

    function handleBackButtonClick() {
        if (currentIndex > 0) {
            currentIndex--;
            updateQuestion();
            nextButton.disabled = false;
        }
        if (currentIndex === 0) {
            backButton.disabled = true;
        }
    }

    function handleNextButtonClick() {
        if (currentIndex < questions.length - 1) {
            currentIndex++;
            updateQuestion();
            backButton.disabled = false;
        }
        if (currentIndex === questions.length - 1) {
            nextButton.disabled = true;
        }
    }

    updateQuestion();

    backButton.addEventListener('click', handleBackButtonClick);
    nextButton.addEventListener('click', handleNextButtonClick);
});
