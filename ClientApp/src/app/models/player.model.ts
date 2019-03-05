import { Position } from 'app/models/constants.model'
import { Team } from 'app/models/team.model'

export class Player {
    playerId: string;
    name: string;
    avatarUrl: string;
    points: number;
    games: number;
    position: Position;

    constructor(player) {
        this.playerId = player.playerId || '0';
        this.name = player.name || '';
        this.avatarUrl = player.avatarUrl || '';
        this.points = player.points || 0;
        this.games = player.games || 0;
        this.position = player.position || Position.Universal;
    }
}