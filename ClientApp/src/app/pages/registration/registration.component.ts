import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from 'app/models/player.model';
import { DataService } from 'app/services/data.service';

import { PlayersRegisterRequest } from 'app/models/requests/players-register-request.model';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})

export class RegistrationComponent {
    players: Player[] = [];

    /**
     * @param {Router} _router
     * @param {DataService} _dataService
     */
    constructor(private _router: Router, private _dataService: DataService) {
        // add two players by default
        this.addNewPlayer();
        this.addNewPlayer();
    }

    addNewPlayer(): void {
        this.players.push(new Player(this));
    }

    finishRegistration(): void {
        let playersRegisterRequest = new PlayersRegisterRequest();
        playersRegisterRequest.players = this.players;

        this._dataService.addPlayers(playersRegisterRequest, (response) => {
            if (response.success) {
                this._router.navigate(['/ratings']);
            }
        });
    }
}