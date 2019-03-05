import { APIResponse } from 'app/models/responses/api-response.model';
import { Game } from 'app/models/game.model';

export class GameRegisterResponse extends APIResponse {
    public games: Game[];
}
