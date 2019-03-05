import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from 'app/models/player.model';
import { DataService } from 'app/services/data.service';

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
        this._dataService.players = this.players;
        this._router.navigate(['/ratings']);
    }
}