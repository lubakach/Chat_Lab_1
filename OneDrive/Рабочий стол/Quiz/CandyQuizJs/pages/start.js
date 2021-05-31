import View from "../View.js";

const resultsNode = document.getElementById('main');
let items = [];

export default {
    setData(newItems) {
        items = newItems;
    },
    render() {
        resultsNode.innerHTML = View.render('start', {list: items});
        document.getElementById('buttonPlay').onclick = play;
        document.getElementById('buttonCreate').onclick = create;

    }
}
function play(){
    window.location.href = window.location.href.split('/').slice(0, -1).join('/')
        + '#menu';
}

function create(){
    window.location.href = window.location.href.split('/').slice(0, -1).join('/')
        + '#nameGame';
}