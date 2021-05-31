import View from "../View.js";
import Model from "../Model.js";

const resultsNode = document.getElementById('main');
let items = [];

export default {
    setData(newItems) {
        items = newItems;
    },
    render() {
        resultsNode.innerHTML = View.render('nameGame', {list: items});
        document.getElementById('buttonOpenCreate').onclick = buttonOpenCreate;
        document.getElementById('buttonOptionCreate').onclick = buttonOptionCreate;
    }
}
function buttonOpenCreate(){
    const form = document.getElementById("createGame");
    let data = {game_name: form.elements.game_name.value };
    const id = Model.putNewGame(data);
    localStorage.setItem("type", '1');
    window.location.href = window.location.href.split('/').slice(0, -1).join('/')
        + '#addQuestion/' + id;
}
function buttonOptionCreate(){
    const form = document.getElementById("createGame");
    let data = {game_name: form.elements.game_name.value };
    const id = Model.putNewGame(data);
    localStorage.setItem("type", '4');
    window.location.href = window.location.href.split('/').slice(0, -1).join('/')
        + '#addQuestion/' + id;
}