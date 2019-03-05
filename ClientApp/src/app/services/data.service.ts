import { Injectable } from '@angular/core';

import { ApiService } from 'app/services/api.service';

import { Player } from 'app/models/player.model';
import { Game } from 'app/models/game.model';

import { GameRegisterRequest } from 'app/models/requests/game-register-request.model';
import { GameResultsRequest } from 'app/models/requests/game-results-request.model';
import { GameRegisterResponse } from 'app/models/responses/game-register-response.model';
import { PlayersResponse } from 'app/models/responses/players-response.model';
import { APIResponse } from '../models/responses/api-response.model';

@Injectable()
export class DataService {

  players: Player[] = [];
  games: Game[] = [];

  constructor(private _apiService: ApiService) {
  }

  getPlayers(callback: (response: PlayersResponse) => void): void {
    this._apiService.getPlayers()
      .subscribe(responce => {
        this.players = responce.players;
        callback(responce);
      });
  }

  registerNewGame(request: GameRegisterRequest, callback: (response: GameRegisterResponse) => void): void {
    this._apiService.registerNewGame(request)
      .subscribe(responce => {
        this.games = responce.games;
        callback(responce);
      });
  }

  saveResults(request: GameResultsRequest, callback: (response: APIResponse) => void): void {
    this._apiService.saveResults(request)
      .subscribe(responce => {
        callback(responce);
      });
  }

  clearPoints(callback: (response: APIResponse) => void): void {
    this._apiService.clearPoints()
      .subscribe(responce => {
        callback(responce);
      });
  }
}