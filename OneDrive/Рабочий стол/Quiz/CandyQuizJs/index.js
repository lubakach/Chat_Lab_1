import Router from "./Router.js";
(async () => {
    try {
        const data = {
            1 : {
                game_name: "KsisQuiz",
                game_id: 1,
                questions: []
            }
        };
        if (!localStorage.games) {
            localStorage.setItem('games', JSON.stringify(data));
        }
        Router.init();


    } catch (e) {
        console.error(e);
        alert('Error: ' + e.message);
    }
})();