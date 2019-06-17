import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from 'app/models/player.model';
import { DataService } from 'app/services/data.service';
import { TeamGeneratorService } from 'app/services/team-generator.service';

@Component({
    selector: 'ratings',
    templateUrl: './rating.component.html',
    styleUrls: ['./rating.component.scss']
})

export class RatingComponent {
    players: Player[] = [];

    /**
     * @param {DataService} _dataService
     * @param {TeamGeneratorService} _teamGeneratorService
     * @param {Router} _router
     */
    constructor(private _dataService: DataService, private _teamGeneratorService: TeamGeneratorService,
        private _router: Router) {

    }

    ngOnInit() {
        if(this.players.length == 0){
            this._dataService.getPlayers((response) => {
                if (response.success) {
                    this.players= this._teamGeneratorService.sortPlayersByPoints(this._dataService.players);
                }
                else{
                    this.goToRegistration();
                }
            });
        }
    }

    goToRegistration(): void {
        this._router.navigate(['registration']);
    }

    goToConfiguration(): void {
        this._router.navigate(['game/game-configuration']);
    }

    clearPlayers(): void {
        if(confirm("Are you sure to clear all players' points ?")){
            this._dataService.clearPoints((response) => {
                if (response.success) {
                    location.reload();
                }
            });
        }
       
    }
}