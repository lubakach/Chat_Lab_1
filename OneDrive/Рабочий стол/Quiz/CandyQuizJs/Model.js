export default {
    getGames(){
        return Object.values(JSON.parse(localStorage.games));
    },
    getGamesDic(){
        return JSON.parse(localStorage.games)
    },
    putNewGame(data){
        const games = JSON.parse(localStorage.games);
        const date = new Date();
        const id = date.getFullYear().toString() +
            date.getMonth().toString() + date.getDate().toString() +
            date.getHours().toString() + date.getMinutes().toString();
        const game = {
            game_name: data.game_name,
            game_id: id,
            questions: []
        }
        games[id] = game;
        localStorage.setItem('games', JSON.stringify(games));
        return id
    },
    getQuestions(gameId){
        const games = JSON.parse(localStorage.games);
        return games[gameId].questions;
    },
    putQuestions(gameId, questions){
        const games = this.getGamesDic()
        games[gameId].questions = questions;
        localStorage.setItem('games', JSON.stringify(games));
        return games[gameId].questions.length;
    },
}