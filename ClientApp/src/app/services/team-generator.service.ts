import { Injectable } from '@angular/core';

import { Player } from 'app/models/player.model';
import { Team } from 'app/models/team.model'
import { Game } from 'app/models/game.model'
import { Position } from 'app/models/constants.model'

@Injectable({
    providedIn: 'root'
})

export class TeamGeneratorService {
    private proPlayers: Player[];
    private unskillPlayers: Player[];

    public randomGenerateChosen : boolean;

    constructor() {
        this.proPlayers = [];
        this.unskillPlayers = [];
    }

    sortPlayersByPoints(players: Player[]): Player[] {

        return players.sort(function (obj1, obj2) {
            if (obj2.points == obj1.points) {
                if (obj1.games == obj2.games) {
                    let random = Math.floor(Math.random() * 2) + 1;
                    return (obj2.games - obj1.games) * (1 - random);
                }
                return obj1.games - obj2.games;
            }
            return obj2.points - obj1.points;
        });
    }

    splitPlayersByRating(players: Player[]): void {
        let sortedByPointsPlayers = this.sortPlayersByPoints(players);
        this.proPlayers = sortedByPointsPlayers.slice(0, players.length / 2);
        this.unskillPlayers = sortedByPointsPlayers.slice(players.length - players.length / 2);
    }

    splitPlayersByRandom(players: Player[]): void {
        let playersCount = players.length;
        while (playersCount > 1) {
            playersCount = players.length;
            let randomPlayerIndex = Math.floor(Math.random() * playersCount);

            if (this.proPlayers < this.unskillPlayers) {
                this.proPlayers.push(players[randomPlayerIndex]);
            }
            else {
                this.unskillPlayers.push(players[randomPlayerIndex]);
            }

            players.splice(randomPlayerIndex, 1);
        }
    }

    generateTeams(players: Player[]): Team[] {
        if (this.randomGenerateChosen) {
            this.splitPlayersByRandom(players);
        }
        else {
            this.splitPlayersByRating(players);
        }

        let teams: Team[] = [];
        let calibrationPlayers = this.unskillPlayers;

        if(players.length % 2 != 0 ){
            var mostPlayedPlayer = calibrationPlayers.reverse().reduce((min, p) => p.games > min.games ? p : min);
            calibrationPlayers.splice(calibrationPlayers.indexOf(mostPlayedPlayer), 1);
        }

        this.proPlayers.forEach(proPlayer => {
            let team: Team = new Team(this);
            team.teamId = (String)(this.proPlayers.indexOf(proPlayer) + 1);
            team.players = [];

            let random = Math.floor(Math.random() * this.unskillPlayers.length);
            let unskillPlayer = this.unskillPlayers[random];
            calibrationPlayers.splice(calibrationPlayers.indexOf(unskillPlayer), 1);

            unskillPlayer.position = Position.Attacker;
            team.players.push(unskillPlayer);

            proPlayer.position = Position.Defender;
            team.players.push(proPlayer);

            teams.push(team);
        });

        return teams;
    }

    generateSingleGame(players: Player[]): void {

    }

    generateTeamGame(teams: Team[]): Game[] {
        let games: Game[] = [];
        let gamesCount = 0;

        for (let teamIndex = 0; teamIndex < teams.length - 1; teamIndex++) {
            if (teamIndex % 2 == 0) {
                teams[teamIndex] = this.swapPlayersRoles(teams[teamIndex]);
            }
            let team = teams[teamIndex];

            for (let opponentIndex = teamIndex + 1; opponentIndex < teams.length; opponentIndex++) {

                let opponentTeam = teams[opponentIndex];
                let game: Game = new Game(this);

                game.gameId = (String)(gamesCount += 1);
                game.teams = [];

                team = this.swapPlayersRoles(team);
                if (teamIndex % 2 != 0) {
                    opponentTeam = this.swapPlayersRoles(opponentTeam);
                }

                //add current game to player profile
                //team.map(t => { t.player.games = game; return t; });
                //opponentTeam.map(t => { t.player.games = game; return t; });

                game.date = new Date().toLocaleDateString();
                game.teams.push(team);
                game.teams.push(opponentTeam);

                games.push(game);
            }
        }

        return games;
    }

    swapPlayersRoles(team: Team): Team {

        //swap positions for database
        let tempPosition = team.players[0].position;
        team.players[0].position = team.players[1].position;
        team.players[1].position = tempPosition;

        //swap players for table display
        let newTeam = new Team(this);
        newTeam.teamId = team.teamId;
        newTeam.players = [team.players[1], team.players[0]];

        return newTeam;
    }
}