import View from "../View.js";
import Model from "../Model.js";
const resultsNode = document.getElementById('main');
let questionBox;
let currentQuestions;
let currentQuestion;
let game_id;
let items = [];


export default {
    setData(newItems){
        items = newItems;
    },
    render(gameId){
        currentQuestions = Model.getQuestions(gameId);
        game_id = gameId;
        if (localStorage.currentQuestion && localStorage.gameId == gameId){
            currentQuestion = JSON.parse(localStorage.currentQuestion);
        }
        else{
            currentQuestion =
                {
                    type : localStorage.type,
                    questionId: currentQuestions.length,
                    time: 90
                };
            currentQuestions.push(currentQuestion);
            localStorage.setItem("currentQuestion", JSON.stringify(currentQuestion));
            localStorage.setItem("gameId", gameId);
        }

        localStorage.setItem("currentQuestions", JSON.stringify(currentQuestions));

        resultsNode.innerHTML = View.render('addQuestion', {list : items});
        questionBox = document.getElementById("CardBox");
        questionBox.innerHTML = View.render('addQuestion1');
        renderQuestion();
        document.getElementById('buttonOpenCreate2').addEventListener('click', function(){
            addQuestion(1);
        });
        document.getElementById('buttonOptionCreate2').addEventListener('click', function(){
            addQuestion(4);
        });
        document.getElementById('buttonFinish2').onclick = publishGame;

    }
}

function getData(){
    if (currentQuestion.type == 4){
        const form = document.getElementById("createQuestion");
        currentQuestion = {
            question: form.elements.question.value,
            answers: [
                form.elements.answer1.value,
                form.elements.answer2.value,
                form.elements.answer3.value,
                form.elements.answer4.value
            ],
            correctAnswer: form.elements["answer"+ (form.elements.radio1.value || "1")].value,
            radioValue: form.elements.radio1.value,
            time: currentQuestion.time,
            type: 4,
            questionId: currentQuestion.questionId
        };
    }
    else{
        const form = document.getElementById("createQuestion");
        currentQuestion = {
            question: form.elements.question.value,
            correctAnswer: form.elements.answer1.value,
            time: currentQuestion.time,
            type: 1,
            questionId: currentQuestion.questionId
        };
    }
    return currentQuestion;
}

function renderQuestion(){
    questionBox.innerHTML = View.render('addQuestion' + currentQuestion.type);
}

function addQuestion(type){
    currentQuestions[currentQuestion.questionId] = getData();
    currentQuestion =
        {
            type : type,
            questionId: currentQuestions.length,
            time: currentQuestion.time
        };
    currentQuestions.push(currentQuestion);
    Model.putQuestions(localStorage.gameId, currentQuestions);
    localStorage.setItem("currentQuestions", JSON.stringify(currentQuestions));
    localStorage.setItem("currentQuestion", JSON.stringify(currentQuestion));
    renderQuestion();
}


function publishGame(){
    currentQuestion = getData()
    currentQuestions[currentQuestion.questionId] = currentQuestion;
    localStorage.removeItem("currentQuestion");
    localStorage.removeItem("currentQuestions");
    Model.putQuestions(game_id, currentQuestions);
    window.location.href = window.location.href.split('/').slice(0, -2).join('/')
        + '/#menu';
}
