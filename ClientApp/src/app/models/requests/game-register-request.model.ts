import { Player } from 'app/models/player.model';

export class GameRegisterRequest {
    public teamMembersCount: number;
    public players: Player[];
}