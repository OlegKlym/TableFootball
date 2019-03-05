import { Component } from '@angular/core';
import { ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

import { DataService } from 'app/services/data.service';
import { Game } from 'app/models/game.model';
import { Team } from 'app/models/team.model';

import { GameResultsRequest } from 'app/models/requests/game-results-request.model';

@Component({
    selector: 'game',
    templateUrl: './game-calibration.component.html',
    styleUrls: ['./game-calibration.component.scss']
})

export class GameCalibrationComponent {
    games: Game[] = [];

    constructor(private _dataService: DataService, private _router: Router,private elRef:ElementRef) { }

    ngOnInit() {
        this.games = this._dataService.games;

        if (this.games.length == 0) {
            this.goToResults();
        }
    }

    goToResults(): void {
        let gameResultsRequest = new GameResultsRequest();
        gameResultsRequest.games = this.games;

        this._dataService.saveResults(gameResultsRequest, (response) => {
             if (response.success) {
                this._router.navigate(['/']);
             }
         });
    }

    winGame(game : Game, team: Team): void {
         game.teamWinnerId = team.teamId;
    }
}