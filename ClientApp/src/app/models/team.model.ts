
import { Player } from 'app/models/player.model'

export class Team {
    teamId: string;
    players: Player[];

    /**
     *
     */
    constructor(team) {
        this.teamId = team.teamId || '0';
        this.players = team.players || null;
    }
}