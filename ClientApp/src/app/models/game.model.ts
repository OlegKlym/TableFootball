import { Team } from 'app/models/team.model'

export class Game {
    gameId: string;
    date: string;
    teams: Team[];
    teamWinnerId: string;

    constructor(game) {
        this.gameId = game.gameId || '0';
        this.date = game.date || '';
        this.teams = game.teams || null;
    }
}