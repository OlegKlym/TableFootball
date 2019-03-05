import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, tap, map, take } from 'rxjs/operators';;

import { Game } from 'app/models/game.model';
import { Player } from 'app/models/player.model';

import { GameRegisterRequest } from 'app/models/requests/game-register-request.model';
import { GameResultsRequest } from 'app/models/requests/game-results-request.model';
import { GameRegisterResponse } from 'app/models/responses/game-register-response.model';
import { PlayersResponse } from 'app/models/responses/players-response.model';
import { APIResponse } from '../models/responses/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _httpClient: HttpClient) { }

  public getPlayers(): Observable<PlayersResponse> {
    let playersUrl =  'https://localhost:5001/api/players';
    let response = new PlayersResponse();

    return this._httpClient.get(playersUrl)
      .pipe(map(data => {
        let playersList = data["players"];
        let players = playersList.map((player) => new Player(player));
        response.players = players;
        return response;
      }),
        catchError(err => {
          console.log(err);
          response.success = false;
          response.error = err;
          return throwError(response);
        }));
  }

  public registerNewGame(request: GameRegisterRequest): Observable<GameRegisterResponse> {
    let gamesUrl =  'https://localhost:5001/assets/games.json';
    let response = new GameRegisterResponse();

    return this._httpClient.get(gamesUrl)
      .pipe(map(data => {
        let gamesList = data["games"];
        let games = gamesList.map((game) => new Game(game));
        response.games = games;
        return response;
      }),
        catchError(err => {
          console.log(err);
          response.success = false;
          response.error = err;
          return throwError(response);
        }));
  }

  public saveResults(request: GameResultsRequest): Observable<APIResponse> {
    return this._httpClient
    .post('https://localhost:5001/api/players', request)
    .pipe(map(data => {
      let responce = new APIResponse();
      return responce;
    }),
      catchError(err => {
        console.log(err);
        let responce = new APIResponse();
        responce.success = false;
        responce.error = err;
        return throwError(responce);
      }));
  }

  public clearPoints(): Observable<APIResponse> {
    return this._httpClient
    .get('https://localhost:5001/api/players/clear')
    .pipe(map(data => {
      let responce = new APIResponse();
      return responce;
    }),
      catchError(err => {
        console.log(err);
        let responce = new APIResponse();
        responce.success = false;
        responce.error = err;
        return throwError(responce);
      }));
  }
}

