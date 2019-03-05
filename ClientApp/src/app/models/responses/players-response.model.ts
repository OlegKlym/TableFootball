import { APIResponse } from 'app/models/responses/api-response.model';
import { Player } from 'app/models/player.model';

export class PlayersResponse extends APIResponse {
    public players: Player[];
}