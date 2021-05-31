/*import View from "../View.js";

const resultsNode = document.getElementById('main');
let items = [];

export default {
    setData(newItems) {
        items = newItems;
    },
    render() {
        resultsNode.innerHTML = View.render('question', {list: items});
        document.getElementById('buttonQuestion').onclick = questionOpen;
    }
}
function questionOpen(){
    window.location.href = window.location.href.split('/').slice(0, -1).join('/')
        + '#questionOpen';
}*/
import View from "../View.js";
import Model from "../Model.js";

const resultsNode = document.getElementById('main');
let playQuestions;
const answers = [];

export default {
    async render(gameId){
        playQuestions = Model.getQuestions(gameId);
        await playGame(0);
    }
}

function playGame(temp){
    let questions = playQuestions;
    let timerId = setTimeout(function q(i = temp){
        if (i != 0){
            let form = document.getElementById('questionT');
            answers.push(form.elements.answer.value);
        }
        if (i == questions.length){
            const result = getResults();
            resultsNode.innerHTML = View.render('result', {result: result, overall: questions.length});
        }
        else{
            resultsNode.innerHTML = View.render("question" + questions[i].type, questions[i]);
            document.getElementById("buttonNextQuestion").onclick = function (){
                clearTimeout(timerId);
                timerId = setTimeout(q, 0, i+1);
            }
            timerId = setTimeout(q, questions[i].time * 1000, i + 1);
        }

    });
}

function getResults(){
    let result = 0;
    for (let i = 0; i < playQuestions.length; i++){
        if (answers[i] == playQuestions[i].correctAnswer){
            result += 1;
        }
    }
    return result;
}