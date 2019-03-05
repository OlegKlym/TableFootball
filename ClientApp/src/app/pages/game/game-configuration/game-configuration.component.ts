import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Player } from 'app/models/player.model';
import { GameRegisterRequest } from 'app/models/requests/game-register-request.model';

import { DataService } from 'app/services/data.service';
import { TeamGeneratorService } from 'app/services/team-generator.service';

@Component({
    selector: 'game',
    templateUrl: './game-configuration.component.html',
    styleUrls: ['./game-configuration.component.scss'],
    providers: [TeamGeneratorService]
})

export class GameConfigurationComponent {
    players: Player[] = [];

    /**
    * @param {DataService} _dataService
    * @param {TeamGeneratorService} _teamGeneratorService
    * @param {Router} _router
    */
    constructor(private _dataService: DataService, private _teamGeneratorService: TeamGeneratorService,
        private _router: Router) {

        this.players = _dataService.players;
    }

    ngOnInit() {
        if (this.players.length == 0) {
            this.goToRegistration();
        }
    }

    randomCheckBoxClicked(): void {
        this._teamGeneratorService.randomGenerateChosen = !this._teamGeneratorService.randomGenerateChosen;
    }

    goToRegistration(): void {
        this._router.navigate(['/']);
    }

    goToTeamCalibration(): void {
        let registerGameRequest = new GameRegisterRequest();
        registerGameRequest.teamMembersCount = 0;
        registerGameRequest.players = this.players;

        let teams = this._teamGeneratorService.generateTeams(this.players);
        this._dataService.games = this._teamGeneratorService.generateTeamGame(teams);
        // this._dataService.registerNewGame(registerGameRequest, (response) => {
        //     if (response.success) {
        this._router.navigate(['game/game-calibration']);
        //     }
        // });
    }

    removePlayer(player: Player): void {
        const index = this.players.indexOf(player, 0);
        if (index > -1) {
            this.players.splice(index, 1);
        }
    }
}